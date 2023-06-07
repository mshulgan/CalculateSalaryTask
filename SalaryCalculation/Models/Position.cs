namespace SalaryCalculation.Models
{
    public class Position
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public List<Employee> Employees { get; set; }
        public List<BaseSalary> BaseSalaries { get; set; }
    }
}