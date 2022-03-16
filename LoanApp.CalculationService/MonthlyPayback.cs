using System;
namespace LoanApp.CalculationService
{
    public struct MonthlyPayback
    {
        public double TotalAmount { get; set; }
        public double Interest { get; set; }
        public double Principal { get; set; }
        public double UnpaidBalance { get; set; }
        public DateTime PaymentDate { get; set; }
        public override bool Equals(object obj)
        {
            var item = (MonthlyPayback)obj;


            return TotalAmount == item.TotalAmount && Interest == item.Interest && Principal == item.Principal && UnpaidBalance == item.UnpaidBalance;
        }
    }
}
