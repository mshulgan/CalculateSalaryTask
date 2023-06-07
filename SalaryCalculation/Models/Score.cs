namespace SalaryCalculation.Models
{
    public class Score
    {
        public Guid Id { get; set; }

        public byte Value { get; set; }

        public double Bonus { get; set; }

        public List<SatisfactionScore> SatisfactionScores { get; set; }
    }
}