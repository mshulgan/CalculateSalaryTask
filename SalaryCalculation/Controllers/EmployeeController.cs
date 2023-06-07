using Microsoft.AspNetCore.Mvc;
using SalaryCalculation.Models;
using SalaryCalculation.Services;

namespace SalaryCalculation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetEmployeesWithSalary")]
        public async Task<IEnumerable<EmployeeResponse>> GetEmployees()
        {
            return await _employeeService.GetEmployeesWithCalculatedSalaryAsync();
        }
    }
}