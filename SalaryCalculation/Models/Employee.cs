using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryCalculation.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid PositionId { get; set; }

        [ForeignKey(nameof(PositionId))]
        public Position Position {  get; set; } 

        public Employee? Manager { get; set; }

        public List<Employee>? Assistants { get; set; }

        public List<SatisfactionScore>? Scores { get; set; }
        public DateTime EmploymentDate { get; set; }
    }
}
