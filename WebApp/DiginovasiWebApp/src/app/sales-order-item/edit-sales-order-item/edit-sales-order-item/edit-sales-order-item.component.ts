import { MaterialDataListResponse } from './../../../material/MaterialResponse';

import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ObjectDataResponse } from 'src/app/ObjectDataResponse';
import Swal from 'sweetalert2';
import { CustomerDataListResponse, CustomerObject } from 'src/app/customer/CustomerResponse';
import { NgbCalendar, NgbDatepicker } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';
import { SalesOrderDataListResponse, SalesOrderObject } from 'src/app/sales-order/SalesOrderResponse';
import { MaterialObject } from 'src/app/material/MaterialResponse';
import { SalesOrderItemDataResponse, SalesOrderItemObject } from '../../SalesOrderItemResponse';

@Component({
  selector: 'app-edit-sales-order-item',
  templateUrl: './edit-sales-order-item.component.html',
  styleUrls: ['./edit-sales-order-item.component.css']
})
export class EditSalesOrderItemComponent implements OnInit {


  public salesOrderItemForm: FormGroup;
  private pathUrl: string = "api/SalesOrderItem/Update";
  private pathGetUrl: string = "api/SalesOrderItem/GetById/";
  private pathMaterialGetAllUrl = "api/Material/GetAll";
  private pathSalesOrderGetAllUrl = "api/SalesOrder/GetAll";

  public listMaterial:Array<MaterialObject> = [];
  public listSalesOrder: Array<SalesOrderObject> = [];
  constructor(private httpClient: HttpClient,  private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {

    this.salesOrderItemForm = new FormGroup({
        id: new FormControl(0),
        salesOrderId: new FormControl(0),
        materialId: new FormControl(0),
        jumlah: new FormControl(0, Validators.required)
    });

    let id = this.activatedRoute.snapshot.paramMap.get("id");
    this.httpClient.get(environment.baseApiUrl.concat(this.pathGetUrl).concat(id))
    .subscribe((result: SalesOrderItemDataResponse) =>{
      if(result.success){
        this.salesOrderItemForm = new FormGroup({
            id: new FormControl(result.data.id),
            salesOrderId: new FormControl(result.data.salesOrderId),
            materialId: new FormControl(result.data.materialId),
            jumlah: new FormControl(result.data.jumlah, Validators.required)
        });
        this.httpClient.get(environment.baseApiUrl.concat(this.pathMaterialGetAllUrl))
        .subscribe((result: MaterialDataListResponse) => {
            if(result.success){
                for(let item of result.data){
                  this.listMaterial.push(item);
                }
            } else {
                Swal.fire("Server Error",result.message,"error");
            }
        }, (error:any) => {
          Swal.fire("Error", "Terjadi error. Mohon dicoba kembali","error");
          console.error(error);
        });

        this.httpClient.get(environment.baseApiUrl.concat(this.pathSalesOrderGetAllUrl))
        .subscribe((result: SalesOrderDataListResponse) => {
            if(result.success){
                for(let item of result.data){
                  this.listSalesOrder.push(item);
                }
            } else {
                Swal.fire("Server Error",result.message,"error");
            }
        }, (error:any) => {
          Swal.fire("Error", "Terjadi error. Mohon dicoba kembali","error");
          console.error(error);
        });
      } else {
          Swal.fire("Server Error",result.message,"error");
      }
    },(error:any) => {
      Swal.fire("Error", "Terjadi error. Mohon dicoba kembali","error");
      console.error(error);
    });

  }


  submitData(): void{
    let materialId: number = Number(this.salesOrderItemForm.get("materialId").value);
    this.salesOrderItemForm.get("materialId").setValue(materialId);

    let salesOrderId: number = Number(this.salesOrderItemForm.get("salesOrderId").value);
    this.salesOrderItemForm.get("salesOrderId").setValue(salesOrderId);


    this.httpClient.put(environment.baseApiUrl.concat(this.pathUrl),
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
