import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ObjectDataResponse } from 'src/app/ObjectDataResponse';
import {ActivatedRoute, Router} from "@angular/router";
import Swal from 'sweetalert2';
import { CustomerDataResponse } from '../CustomerResponse';
@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.css']
})
export class EditCustomerComponent implements OnInit {

  public customerForm: FormGroup;
  private pathGetUrl: string = "api/Customer/GetById/";
  private pathPutUrl: string = "api/Customer/Update";

  private currentRouteId: string = "0";
  constructor(private httpClient: HttpClient, private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {

    this.customerForm = new FormGroup({
      id: new FormControl(0),
      noCustomer: new FormControl(""),
      nama: new FormControl("", Validators.required),
      noKontak: new FormControl("", Validators.required)
    });
    this.activatedRoute.paramMap.subscribe(value => {
      this.currentRouteId = value.get("id");
      console.log(this.currentRouteId);
      this.httpClient
      .get(environment.baseApiUrl.concat(this.pathGetUrl).concat(this.currentRouteId))
      .subscribe((response: CustomerDataResponse) => {
          if(response.success){
              this.customerForm.get("id").setValue(response.data?.id);
              this.customerForm.get("noCustomer").setValue(response.data?.noCustomer);
              this.customerForm.get("nama").setValue(response.data?.nama);
              this.customerForm.get("noKontak").setValue(response.data?.noKontak);
          } else {
            Swal.fire("Server Error", response.message);
          }
      });

    })
  }
  submitData(): void{
    this.httpClient.put(environment.baseApiUrl.concat(this.pathPutUrl), this.customerForm.value)
    .subscribe((response: ObjectDataResponse<number>) => {
        Swal.fire("Response server", response.message, "success").then(() => {
          this.router.navigate(["customer","list"]);
        });
        this.customerForm.reset();
    },(error:any) => {
      Swal.fire("Error", "Terjadi error. Mohon dicoba kembali","error");
      console.error(error);
    })
  }
}
