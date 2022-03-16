using System;
using System.Collections.Generic;

namespace LoanApp.CalculationService.Interfaces
{
    public interface ILoanCalculationService
    {
        IEnumerable<MonthlyPayback> GetMortgageEqualAmountLoanSchedule(double amount, int years);
    }
}
