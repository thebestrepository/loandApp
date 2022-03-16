using System;
using Xunit;

namespace LoanApp.CalculationService.UnitTests
{
    public class EqualPrincipleLoanUnitTests
    {

        [Fact]
        public void EqualPrinciple_GetMonthlyPayback_Calculated()
        {
            var loanScheme = new EqualPrincipleLoanScheme();
            var expectedResult = new MonthlyPayback { Interest = 1050, Principal = 1250, TotalAmount = 2300, UnpaidBalance = 7500 };
            MonthlyPayback result = loanScheme.GetMonthlyPayback(7, 8750, 0.12);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void EqualAmount_GetMonthlyPayback_Calculated()
        {
            var loanScheme = new EqualAmountLoanScheme();
            var expectedResult = new MonthlyPayback { Interest = 1200, Principal = 813.03, TotalAmount = 2013.03, UnpaidBalance = 9186.97 };
            MonthlyPayback result = loanScheme.GetMonthlyPayback(8, 10000.00, 0.12);
            Assert.Equal(expectedResult, result);
        }
    }
}
