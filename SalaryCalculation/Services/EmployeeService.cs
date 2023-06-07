using SalaryCalculation.Helpers;
using SalaryCalculation.Models;
using SalaryCalculation.Repositories;

namespace SalaryCalculation.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponse>> GetEmployeesWithCalculatedSalaryAsync();
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IConfiguration _configuration;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICalculationHelper _calculationHelper;

        public EmployeeService(IConfiguration configuraion, IEmployeeRepository employeeRepository, ICalculationHelper calculationHelper)
        {
            _configuration = configuraion;
            _employeeRepository = employeeRepository;
            _calculationHelper = calculationHelper;
        }

        public async Task<IEnumerable<EmployeeResponse>> GetEmployeesWithCalculatedSalaryAsync()
        {
            var employeesData = await _employeeRepository.GetEmployeesAsync();
            var averageDaysinYear = _configuration.GetValue<double>("AverageDaysInYear");

            return employeesData.Select(e =>
            {
                var baseSalary = e.Position.BaseSalaries
                                .Where(bs => (DateTime.Now.Subtract(e.EmploymentDate).TotalDays/ averageDaysinYear) >= bs.MinExperience)
                                .OrderByDescending(bs => bs.MinExperience)
                                .First().Salary;

                var minWage = _configuration.GetValue<decimal>("MinimumWage");

                var lastThreeScores = e.Scores.Count != 0 ? e.Scores.OrderByDescending(bs => bs.Year).Select(x => x.Score.Value).Take(3).ToArray() : Array.Empty<byte>();

                var salary = _calculationHelper.CalculateSalary(baseSalary, minWage, lastThreeScores);
                return new EmployeeResponse
                {
                    Name = e.Name,
                    Position = e.Position.Title,
                    Salary = salary
                };
            });
        }
    }
}
