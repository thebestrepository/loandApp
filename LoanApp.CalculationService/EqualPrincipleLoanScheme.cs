using System;
using LoanApp.CalculationService.Interfaces;

namespace LoanApp.CalculationService
{
    public class EqualPrincipleLoanScheme : LoanScheme
    {
        public EqualPrincipleLoanScheme()
        {

        }

        public override MonthlyPayback GetMonthlyPayback(int monthsLeft, double unpaidBalance, double interestRate)
        {
            m_interestRate = interestRate;
            var interest = Math.Round(CalculateInterest(unpaidBalance, monthsLeft), 2);
            var principle = Math.Round(CalculatePrincipal(unpaidBalance, monthsLeft), 2);
            return new MonthlyPayback { Interest = interest, Principal = principle, TotalAmount = interest + principle, UnpaidBalance = unpaidBalance - principle };
        }

        double CalculatePrincipal(double amount, int periodsCount)
        {
            return Math.Round(amount / periodsCount, 2);
        }

        double CalculateInterest(double amount, int periodsCount)
        {
            return amount * m_interestRate;
        }
    }
}
