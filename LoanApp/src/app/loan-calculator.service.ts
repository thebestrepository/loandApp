import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, retry } from "rxjs/operators";
import { LoanConfig, PaymentSchedule } from "./payment-schedule";

@Injectable({
  providedIn: "root",
})
export class LoanCalculatorService {
  constructor(private http: HttpClient) {}

  fetchSchedule(loan: LoanConfig): Observable<PaymentSchedule> {
    let url = `https://localhost:5001/loan?amount=${loan.amount}&years=${loan.years}`;
    const httpOptions = {
      headers: new HttpHeaders({ "Content-Type": "application/json" }),
    };
    return this.http.get<PaymentSchedule>(url, httpOptions);
  }
}
