import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ObjectDataResponse } from 'src/app/ObjectDataResponse';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-add-satuan',
  templateUrl: './add-satuan.component.html',
  styleUrls: ['./add-satuan.component.css']
})
export class AddSatuanComponent implements OnInit {

  public satuanForm: FormGroup;
  private pathUrl: string = "api/Satuan/Add";

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    this.satuanForm = new FormGroup({
        kode: new FormControl("", Validators.required),
        deskripsi: new FormControl("")
    });
  }
  submitData(): void{
    this.httpClient.post(environment.baseApiUrl.concat(this.pathUrl), this.satuanForm.value)
    .subscribe((response: ObjectDataResponse<number>) => {
        Swal.fire("Response server", response.message, "success");
        this.satuanForm.reset();
    },(error:any) => {
      Swal.fire("Error", "Terjadi error. Mohon dicoba kembali","error");
      console.error(error);
    })
  }
}
