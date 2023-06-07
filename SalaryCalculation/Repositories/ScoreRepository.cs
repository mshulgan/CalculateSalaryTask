using Microsoft.EntityFrameworkCore;
using SalaryCalculation.Models;

namespace SalaryCalculation.Repositories
{
    public interface IScoreRepository
    {
        double GetScoreBonusByValue(byte value);
    }

    public class ScoreRepository : IScoreRepository
    {
        private readonly ApplicationContext _context;
        public ScoreRepository(ApplicationContext context)
        {
            _context = context;
        }

        public double GetScoreBonusByValue(byte value)
        {
            return _context.Set<Score>().Where(x => x.Value == value).First().Bonus;
        }
    }
}
