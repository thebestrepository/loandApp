using System;
using LoanApp.CalculationService.Interfaces;

namespace LoanApp.CalculationService
{
    public class MortgageLoan : ILoan
    {
        double m_interestRate;
        LoanScheme m_scheme;
        public MortgageLoan(double interestRate, LoanScheme scheme)
        {
            m_interestRate = interestRate;
            m_scheme = scheme;
        }

        public double InterestRate { get => m_interestRate; set => m_interestRate = value; }
        public LoanScheme Scheme { get => m_scheme; set => m_scheme = value; }

        public MonthlyPayback GetMonthlyPayback(int monthsLeft, double amountToPay)
        {
            return m_scheme.GetMonthlyPayback(monthsLeft, amountToPay, m_interestRate);
        }
    }
}
