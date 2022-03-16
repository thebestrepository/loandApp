import {
  AfterViewInit,
  Component,
  Input,
  OnInit,
  SimpleChanges,
  ViewChild,
} from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { MonthlyPayment, PaymentSchedule } from "../payment-schedule";
import { formatDate } from "@angular/common";
import "@angular/common/locales/global/pl";

@Component({
  selector: "app-loan-payment-schedule",
  templateUrl: "./loan-payment-schedule.component.html",
  styleUrls: ["./loan-payment-schedule.component.scss"],
})
export class LoanPaymentScheduleComponent implements AfterViewInit {
  @Input() scheduleData: PaymentSchedule;
  displayedColumns: string[] = [
    "paymentDate",
    "interest",
    "principal",
    "unpaidBalance",
    "totalPayment",
  ];
  dataSource: MatTableDataSource<MonthlyPayment> = new MatTableDataSource();

  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngAfterViewInit() {
    console.log("paginator", this.paginator);
    this.dataSource.paginator = this.paginator;
  }
  constructor() {}
  ngOnChanges(changes: SimpleChanges) {
    this.dataSource.data = changes.scheduleData.currentValue;

    if (this.paginator && this.dataSource.data !== undefined) {
      this.dataSource.paginator = this.paginator;
      this.dataSource.paginator.firstPage();
    }
  }
  formatPaymentDate(date: string) {
    return formatDate(date, "yyyy/MM/dd", "pl");
  }
  ngOnInit(): void {}
}
