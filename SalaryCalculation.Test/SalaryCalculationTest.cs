using Moq;
using SalaryCalculation.Helpers;
using SalaryCalculation.Repositories;

namespace SalaryCalculation.Test
{
    public class SalaryCalculationTest
    {
        [Fact]
        public void ShouldReturnCalculatedSalary()
        {
            var expectedBonus = 1.15;
            byte expectedAverageScore = 4;
            var lastThreeScores = new byte[] { 5, 3, 1 };
            var baseSalary = 1200;
            var minWage = 800;
            var mockedScoreRepository = new Mock<IScoreRepository>();
            ICalculationHelper calculationHelper = new CalculationHelper(mockedScoreRepository.Object);
            mockedScoreRepository.Setup(x => x.GetScoreBonusByValue(expectedAverageScore)).Returns(expectedBonus);

            var calculatedSalary = calculationHelper.CalculateSalary(baseSalary, minWage, lastThreeScores);

            Assert.Equal(2180, calculatedSalary);
        }
    }
}