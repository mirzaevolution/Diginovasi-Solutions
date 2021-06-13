import { MaterialDataListResponse } from './../../../material/MaterialResponse';

import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ObjectDataResponse } from 'src/app/ObjectDataResponse';
import Swal from 'sweetalert2';
import { CustomerDataListResponse, CustomerObject } from 'src/app/customer/CustomerResponse';
import { NgbCalendar, NgbDatepicker } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { SalesOrderDataListResponse, SalesOrderObject } from 'src/app/sales-order/SalesOrderResponse';
import { MaterialObject } from 'src/app/material/MaterialResponse';

@Component({
  selector: 'app-add-sales-order-item',
  templateUrl: './add-sales-order-item.component.html',
  styleUrls: ['./add-sales-order-item.component.css']
})
export class AddSalesOrderItemComponent implements OnInit {


  public salesOrderItemForm: FormGroup;
  private pathUrl: string = "api/SalesOrderItem/Add";
  private pathMaterialGetAllUrl = "api/Material/GetAll";
  private pathSalesOrderGetAllUrl = "api/SalesOrder/GetAll";

  public listMaterial:Array<MaterialObject> = [];
  public listSalesOrder: Array<SalesOrderObject> = [];
  constructor(private httpClient: HttpClient,  private router: Router) { }

  ngOnInit(): void {

    this.salesOrderItemForm = new FormGroup({
        salesOrderId: new FormControl(0),
        materialId: new FormControl(0),
        jumlah: new FormControl(0, Validators.required)
    });

    this.httpClient.get(environment.baseApiUrl.concat(this.pathMaterialGetAllUrl))
    .subscribe((result: MaterialDataListResponse) => {
        if(result.success){
            for(let item of result.data){
              this.listMaterial.push(item);
            }
            if(this.listMaterial.length>0){
                this.salesOrderItemForm.get("materialId").setValue(this.listMaterial[0].id);
            }
        } else {
            Swal.fire("Server Error",result.message,"error");
        }
    });

    this.httpClient.get(environment.baseApiUrl.concat(this.pathSalesOrderGetAllUrl))
    .subscribe((result: SalesOrderDataListResponse) => {
        if(result.success){
            for(let item of result.data){
              this.listSalesOrder.push(item);
            }
            if(this.listSalesOrder.length>0){
                this.salesOrderItemForm.get("salesOrderId").setValue(this.listSalesOrder[0].id);
            }
        } else {
            Swal.fire("Server Error",result.message,"error");
        }
    });
  }


  submitData(): void{
    let materialId: number = Number(this.salesOrderItemForm.get("materialId").value);
    this.salesOrderItemForm.get("materialId").setValue(materialId);

    let salesOrderId: number = Number(this.salesOrderItemForm.get("salesOrderId").value);
    this.salesOrderItemForm.get("salesOrderId").setValue(materialId);


    this.httpClient.post(environment.baseApiUrl.concat(this.pathUrl),
    this.salesOrderItemForm.value)
    .subscribe((response: ObjectDataResponse<number>) => {
      Swal.fire("Response server", response.message, "success").then(() => {
        this.router.navigate(["sales-order-item","list"]);
      });

    },(error:any) => {
      Swal.fire("Error", "Terjadi error. Mohon dicoba kembali","error");
      console.error(error);
    });
  }
}
