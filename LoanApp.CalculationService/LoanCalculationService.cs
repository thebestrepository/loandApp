using System;
using System.Collections.Generic;
using LoanApp.CalculationService.Interfaces;

namespace LoanApp.CalculationService
{
    public class LoanCalculationService : ILoanCalculationService
    {
        
        public LoanCalculationService()
        {
        }
        
        private IEnumerable<MonthlyPayback> GetLoanSchedule(ILoan loan, double amount, int years)
        {
            if (amount == 0 || years == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            int monthsCount = years*12;
            List<MonthlyPayback> result = new List<MonthlyPayback>();
            var startDate = DateTime.Now;
            for (int i=monthsCount; i >= 1; i--)
            {
                var monthlyPayback = loan.GetMonthlyPayback(i, amount);
                monthlyPayback.PaymentDate = startDate.AddMonths(years - i+1);
                result.Add(monthlyPayback);
                amount -= monthlyPayback.Principal;
            }
            return result;
        }

        public IEnumerable<MonthlyPayback> GetMortgageEqualAmountLoanSchedule(double amount, int years)
        {
            var loan = new MortgageLoan(0.035, new EqualAmountLoanScheme());
            return GetLoanSchedule(loan, amount, years);
        }
    }
}
