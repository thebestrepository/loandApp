using System;
namespace LoanApp.CalculationService.Interfaces
{
    public abstract class LoanScheme
    {
        protected double m_interestRate;
        public abstract MonthlyPayback GetMonthlyPayback(int monthsLeft, double unpaidBalance, double interestRate);
        
    }
}
