import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ObjectDataResponse } from 'src/app/ObjectDataResponse';
import {ActivatedRoute, Router} from "@angular/router";
import Swal from 'sweetalert2';
import { SatuanDataResponse } from '../SatuanResponse';
@Component({
  selector: 'app-edit-satuan',
  templateUrl: './edit-satuan.component.html',
  styleUrls: ['./edit-satuan.component.css']
})
export class EditSatuanComponent implements OnInit {

  public satuanForm: FormGroup;
  private pathGetUrl: string = "api/Satuan/GetById/";
  private pathPutUrl: string = "api/Satuan/Update";

  private currentRouteId: string = "0";
  constructor(private httpClient: HttpClient, private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {

    this.satuanForm = new FormGroup({
      id: new FormControl(0),
      kode: new FormControl("", Validators.required),
      deskripsi: new FormControl("", Validators.required)
  });
    this.activatedRoute.paramMap.subscribe(value => {
      this.currentRouteId = value.get("id");
      console.log(this.currentRouteId);
      this.httpClient
      .get(environment.baseApiUrl.concat(this.pathGetUrl).concat(this.currentRouteId))
      .subscribe((response: SatuanDataResponse) => {
          if(response.success){
              this.satuanForm.get("id").setValue(response.data?.id);
              this.satuanForm.get("kode").setValue(response.data?.kode);
              this.satuanForm.get("deskripsi").setValue(response.data?.deskripsi);

          } else {
            Swal.fire("Server Error", response.message, "error");
          }
      });

    })
  }
  submitData(): void{

    this.httpClient.put(environment.baseApiUrl.concat(this.pathPutUrl), this.satuanForm.value)
    .subscribe((response: ObjectDataResponse<number>) => {
        Swal.fire("Response server", response.message, "success").then(() => {
          this.router.navigate(["satuan","list"]);
        });
        this.satuanForm.reset();
    },(error:any) => {
      Swal.fire("Error", "Terjadi error. Mohon dicoba kembali","error");
      console.error(error);
    })
  }
}
