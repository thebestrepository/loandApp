export class PaymentSchedule {
  payments: MonthlyPayment[];
}

export interface MonthlyPayment {
  paymentDate: Date;
  totalAmount: number;
  intrest: number;
  principal: number;
  unpaidBalance: number;
}

export class LoanConfig {
  amount: number;
  years: number;
}
