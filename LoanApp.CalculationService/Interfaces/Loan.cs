using System;
namespace LoanApp.CalculationService.Interfaces
{
    public interface ILoan
    {
        public double InterestRate { get; set; }
        public LoanScheme Scheme { get; set; }
        MonthlyPayback GetMonthlyPayback(int monthsLeft, double amountToPay);
    }
}
