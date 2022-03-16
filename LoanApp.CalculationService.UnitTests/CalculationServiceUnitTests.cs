using System;
using System.Linq;
using LoanApp.CalculationService.Interfaces;
using Moq;
using Xunit;

namespace LoanApp.CalculationService.UnitTests
{
    public class CalculationServiceUnitTests
    {
        [Fact]
        public void LoanCalculationService_MortgageEqualAmountLoan_ReturnCorrectNumberOfPayments()
        {
            var calculationService = new LoanCalculationService();
            var result = calculationService.GetMortgageEqualAmountLoanSchedule(10000, 8).ToList();
            Assert.True(result.Count == 8 * 12);
        }

        [Fact]
        public void LoanCalculationService_MortgageEqualAmountLoan_ReturnCorrectTotalAmountInPayments()
        {
            var calculationService = new LoanCalculationService();
            var result = calculationService.GetMortgageEqualAmountLoanSchedule(10000, 8).ToList();
            var first = result.First().TotalAmount;
            Assert.True(result.All(p => p.TotalAmount == first));
        }


        [Fact]
        public void LoanCalculationService_MortgageEqualAmountLoan_ThrowsExceptionWhenArgumentsAreInvalid()
        {
            var calculationService = new LoanCalculationService();
            Assert.Throws<ArgumentOutOfRangeException>(() => calculationService.GetMortgageEqualAmountLoanSchedule(0, 0));
        }
    }
}
