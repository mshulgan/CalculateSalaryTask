using Microsoft.EntityFrameworkCore;
using SalaryCalculation.Models;

namespace SalaryCalculation.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;

        public EmployeeRepository(ApplicationContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.Select(e => new Employee
            {
                Name = e.Name,
                Position = new Position
                {
                    Title = e.Position.Title,
                    BaseSalaries = e.Position.BaseSalaries
                },
                Scores = e.Scores == null || !e.Scores.Any() ? new List<SatisfactionScore>() :  e.Scores.Select(s => new SatisfactionScore 
                {
                    Score = s.Score,
                    Year = s.Year
                }).ToList(),
                EmploymentDate = e.EmploymentDate
            }).ToListAsync();
        }
    }
}
