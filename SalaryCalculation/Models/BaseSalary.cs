namespace SalaryCalculation.Models
{
    public class BaseSalary
    {
        public Guid Id { get; set; }

        public byte MinExperience { get; set; }

        public decimal Salary { get; set; }

        public Guid PositionId { get; set; }

        public Position Position { get; set; }
    }
}