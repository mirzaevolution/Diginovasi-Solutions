import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ObjectDataResponse } from 'src/app/ObjectDataResponse';
import Swal from 'sweetalert2';
import { CustomerDataListResponse, CustomerObject } from 'src/app/customer/CustomerResponse';
import { NgbCalendar, NgbDatepicker } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-sales-order',
  templateUrl: './add-sales-order.component.html',
  styleUrls: ['./add-sales-order.component.css']
})
export class AddSalesOrderComponent implements OnInit {

  public salesOrderForm: FormGroup;
  private pathUrl: string = "api/SalesOrder/Add";
  private pathCustomerGetAllUrl = "api/customer/GetAll";
  public listCustomer:Array<CustomerObject> = [];
  @ViewChild("datePicker") datePicker: NgbDatepicker;

  constructor(private httpClient: HttpClient, private calendarService: NgbCalendar, private router: Router) { }

  ngOnInit(): void {

    this.salesOrderForm = new FormGroup({
      tanggalStruct: new FormControl(this.calendarService.getToday()),
      customerId: new FormControl(0),
    });
    this.httpClient.get(environment.baseApiUrl.concat(this.pathCustomerGetAllUrl))
    .subscribe((result: CustomerDataListResponse) => {
        if(result.success){
            for(let item of result.data){
              this.listCustomer.push(item);
            }
            if(this.listCustomer.length>0){
                this.salesOrderForm.get("customerId").setValue(this.listCustomer[0].id);
            }
        } else {
            Swal.fire("Server Error",result.message,"error");
        }
    });
  }


  submitData(): void{
    let custId: number = Number(this.salesOrderForm.get("customerId").value);
    this.salesOrderForm.get("customerId").setValue(custId);
    this.httpClient.post(environment.baseApiUrl.concat(this.pathUrl),
    this.salesOrderForm.value)
    .subscribe((response: ObjectDataResponse<number>) => {
      Swal.fire("Response server", response.message, "success").then(() => {
        this.router.navigate(["sales-order","list"]);
      });

    },(error:any) => {
      Swal.fire("Error", "Terjadi error. Mohon dicoba kembali","error");
      console.error(error);
    });
    console.log(this.salesOrderForm.value);
  }
}
