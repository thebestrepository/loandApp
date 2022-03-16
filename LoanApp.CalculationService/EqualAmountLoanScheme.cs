using System;
using LoanApp.CalculationService.Interfaces;

namespace LoanApp.CalculationService
{
    public class EqualAmountLoanScheme : LoanScheme
    {
        public EqualAmountLoanScheme()
        {
            
        }

        public override MonthlyPayback GetMonthlyPayback(int monthsLeft, double unpaidBalance, double interestRate)
        {
            m_interestRate = interestRate;
            var periodTotalAmount = Math.Round(CalculatePeriodTotalAmount(unpaidBalance, monthsLeft), 2);
            var principal = Math.Round(CalculatePrincipal(unpaidBalance, monthsLeft), 2);
            var interest = Math.Round(CalculateInterest(periodTotalAmount, principal), 2);
            return new MonthlyPayback { Interest = interest, Principal = principal, TotalAmount = periodTotalAmount, UnpaidBalance = unpaidBalance - principal };
        }

        double CalculatePrincipal(double amount, int periodsCount)
        {
            return CalculatePeriodTotalAmount(amount,periodsCount) * Math.Pow((1+m_interestRate),-(periodsCount));
        }

        double CalculateInterest(double periodTotalAmount,double principal)
        {
            return periodTotalAmount - principal;
        }

        double CalculatePeriodTotalAmount(double amount, int periodsCount)
        {
            return (m_interestRate * amount) / (1 - Math.Pow((1 + m_interestRate), -periodsCount));
        }
    }
}
