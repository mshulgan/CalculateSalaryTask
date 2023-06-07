using SalaryCalculation.Repositories;

namespace SalaryCalculation.Helpers
{
    public interface ICalculationHelper
    {
        decimal CalculateSalary(decimal baseSalary, decimal minimumWage, byte[] bonuses);
    }

    public class CalculationHelper : ICalculationHelper
    {
        private readonly IScoreRepository _scoreRepository;
        public CalculationHelper(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        public decimal CalculateSalary(decimal baseSalary, decimal minimumWage, byte[] bonuses)
        {
            byte finalScore;
            if (bonuses.Length == 3)
            {
                finalScore = (byte)Math.Ceiling(Average(bonuses[0], Average(bonuses[1], bonuses[2])));
            }
            else if (bonuses.Length == 2)
            {
                finalScore = (byte)Math.Ceiling(Average(bonuses[0], bonuses[1]));
            }
            else if (bonuses.Length == 1)
            {
                finalScore = bonuses[0];
            }
            else
            {
                finalScore = 0;
            }

            var finalBonus = (decimal)_scoreRepository.GetScoreBonusByValue(finalScore);

            return minimumWage + baseSalary * finalBonus;
        }

        private static double Average(double a, double b)
        {
            return (a + b) / 2;
        }
    }
}
