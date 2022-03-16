import { Component } from "@angular/core";
import { PaymentSchedule } from "./payment-schedule";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"],
})
export class AppComponent {
  paymentSchedule: PaymentSchedule;
  onPaymentSchedule(schedule: PaymentSchedule) {
    this.paymentSchedule = schedule;
  }
  title = "LoanApp";
}
