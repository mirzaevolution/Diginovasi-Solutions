import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ObjectDataResponse } from 'src/app/ObjectDataResponse';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnInit {
  public customerForm: FormGroup;
  private pathUrl: string = "api/Customer/Add";

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    this.customerForm = new FormGroup({
        nama: new FormControl("", Validators.required),
        noKontak: new FormControl("", Validators.required)
    });
  }
  submitData(): void{
    this.httpClient.post(environment.baseApiUrl.concat(this.pathUrl), this.customerForm.value)
    .subscribe((response: ObjectDataResponse<number>) => {
        Swal.fire("Response server", response.message, "success");
        this.customerForm.reset();
    },(error:any) => {
      Swal.fire("Error", "Terjadi error. Mohon dicoba kembali","error");
      console.error(error);
    })
  }
}
