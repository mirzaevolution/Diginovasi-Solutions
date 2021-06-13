import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ObjectDataResponse } from 'src/app/ObjectDataResponse';
import Swal from 'sweetalert2';
import { SatuanDataListResponse, SatuanObject } from '../../satuan/SatuanResponse';
@Component({
  selector: 'app-add-material',
  templateUrl: './add-material.component.html',
  styleUrls: ['./add-material.component.css']
})
export class AddMaterialComponent implements OnInit {

  public materialForm: FormGroup;
  private pathUrl: string = "api/material/Add";
  private pathSatuanGetAllUrl = "api/satuan/GetAll";
  public listSatuan:Array<SatuanObject> = [];
  @ViewChild("formControlGambar") formControlGambar: ElementRef;
  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {

    this.materialForm = new FormGroup({
      kode: new FormControl("", Validators.required),
      deskripsi: new FormControl(""),
      harga: new FormControl(0),
      selectedSatuan: new FormControl(0),
      gambar: new FormControl(null)
    });
    this.httpClient.get(environment.baseApiUrl.concat(this.pathSatuanGetAllUrl))
    .subscribe((result: SatuanDataListResponse) => {
        if(result.success){
            for(let item of result.data){
              this.listSatuan.push(item);
            }
            if(this.listSatuan.length>0){
                this.materialForm.get("selectedSatuan").setValue(this.listSatuan[0].id);
            }
        } else {
            Swal.fire("Server Error",result.message,"error");
        }
    });
  }

  gambarChange(event): void{
      try{
        if(event.target.files.length>0){
          let file = event.target.files[0];
          this.materialForm.get("gambar").setValue(file);

        }
      } catch(err){
        console.log(err);
      }
  }
  submitData(): void{
    let formData: FormData = new FormData();
    formData.append("kode", this.materialForm.get("kode").value);
    formData.append("deskripsi", this.materialForm.get("deskripsi").value);
    formData.append("harga", this.materialForm.get("harga").value);
    formData.append("satuanId", this.materialForm.get("selectedSatuan").value);
    formData.append("gambar", this.materialForm.get("gambar").value);
    this.httpClient.post(environment.baseApiUrl.concat(this.pathUrl),
    formData)
    .subscribe((response: ObjectDataResponse<number>) => {
        Swal.fire("Response server", response.message, "success");
        this.materialForm.reset();
        this.formControlGambar.nativeElement.value = null;

    },(error:any) => {
      Swal.fire("Error", "Terjadi error. Mohon dicoba kembali","error");
      console.error(error);
    });
  }
}
