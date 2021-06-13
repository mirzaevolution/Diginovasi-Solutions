import { SalesOrderDataResponse } from './../../SalesOrderResponse';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ObjectDataResponse } from 'src/app/ObjectDataResponse';
import Swal from 'sweetalert2';
import { CustomerDataListResponse, CustomerObject } from 'src/app/customer/CustomerResponse';
import { NgbCalendar, NgbDatepicker } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-edit-sales-order',
  templateUrl: './edit-sales-order.component.html',
  styleUrls: ['./edit-sales-order.component.css']
})
export class EditSalesOrderComponent implements OnInit {


  public salesOrderForm: FormGroup;
  private pathUpdateUrl: string = "api/SalesOrder/Update";
  private pathGetUrl: string = "api/SalesOrder/GetById/";
  private pathCustomerGetAllUrl = "api/customer/GetAll";
  public listCustomer:Array<CustomerObject> = [];
  @ViewChild("datePicker") datePicker: NgbDatepicker;

  constructor(private httpClient: HttpClient,
    private calendarService: NgbCalendar,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {

    this.salesOrderForm = new FormGroup({
      id: new FormControl(0),
      noSalesOrder: new FormControl(""),
      tanggalStruct: new FormControl(this.calendarService.getToday()),
      customerId: new FormControl(0),
    });

    this.httpClient.get(environment.baseApiUrl.concat(this.pathGetUrl).concat(this.activatedRoute.snapshot.paramMap.get("id")))
    .subscribe((result:SalesOrderDataResponse) => {
        if(result.success){
          this.salesOrderForm = new FormGroup({
            id: new FormControl(result.data.id),
            noSalesOrder: new FormControl(result.data.noSalesOrder),
            tanggalStruct: new FormControl(result.data.tanggalStruct),
            customerId: new FormControl(result.data.customerId),
          });
          this.httpClient.get(environment.baseApiUrl.concat(this.pathCustomerGetAllUrl))
          .subscribe((result: CustomerDataListResponse) => {
              if(result.success){
                  for(let item of result.data){
                    this.listCustomer.push(item);
                  }
              } else {
                  Swal.fire("Server Error",result.message,"error");
              }
          });
        }  else {
          Swal.fire("Server Error", result.message, "error");
        }
    },(error:any) => {
      Swal.fire("Error", "Terjadi error. Mohon dicoba kembali","error");
      console.error(error);
    });



  }


  submitData(): void{
    let custId: number = Number(this.salesOrderForm.get("customerId").value);
    this.salesOrderForm.get("customerId").setValue(custId);
    this.httpClient.put(environment.baseApiUrl.concat(this.pathUpdateUrl),
    this.salesOrderForm.value)
    .subscribe((response: ObjectDataResponse<number>) => {
      Swal.fire("Response server", response.message, "success").then(() => {
        this.router.navigate(["sales-order","list"]);
      });
    },(error:any) => {
      Swal.fire("Error", "Terjadi error. Mohon dicoba kembali","error");
      console.error(error);
    });
  }
}
