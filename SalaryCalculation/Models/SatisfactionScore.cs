namespace SalaryCalculation.Models
{
    public class SatisfactionScore
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public Guid ScoreId { get; set; }

        public Score Score { get; set; }

        public uint Year { get; set; }

    }
}
