import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ObjectDataResponse } from 'src/app/ObjectDataResponse';
import Swal from 'sweetalert2';
import { SatuanDataListResponse, SatuanDataResponse, SatuanObject } from '../../satuan/SatuanResponse';
import { MaterialDataResponse } from '../MaterialResponse';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-edit-material',
  templateUrl: './edit-material.component.html',
  styleUrls: ['./edit-material.component.css']
})
export class EditMaterialComponent implements OnInit {

  public materialForm: FormGroup;
  private pathUpdateUrl: string = "api/material/Update";
  private pathGetUrl: string = "api/material/GetById/";
  private pathSatuanGetAllUrl = "api/satuan/GetAll";
  public viewableGambar: string;
  public listSatuan:Array<SatuanObject> = [];
  @ViewChild("formControlGambar") formControlGambar: ElementRef;
  constructor(private httpClient: HttpClient, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {

    this.materialForm = new FormGroup({
      id: new FormControl(0),
      kode: new FormControl("", Validators.required),
      deskripsi: new FormControl(""),
      harga: new FormControl(0),
      selectedSatuan: new FormControl(0),
      gambar: new FormControl(null),
      urlGambar: new FormControl("")
    });
    this.httpClient.get(environment.baseApiUrl.concat(this.pathGetUrl).concat(this.activatedRoute.snapshot.paramMap.get("id")))
    .subscribe((result: MaterialDataResponse) => {
      if(result.success){
        this.materialForm.get("id").setValue(result.data.id);
        this.materialForm.get("kode").setValue(result.data.kode);
        this.materialForm.get("deskripsi").setValue(result.data.deskripsi);
        this.materialForm.get("harga").setValue(result.data.harga);
        this.materialForm.get("selectedSatuan").setValue(result.data.satuanId);
        this.materialForm.get("urlGambar").setValue(result.data.urlGambar);
        this.viewableGambar = environment.baseApiUrl.concat(result.data.formattedUrlGambar);
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
    formData.append("id", this.materialForm.get("id").value);
    formData.append("kode", this.materialForm.get("kode").value);
    formData.append("deskripsi", this.materialForm.get("deskripsi").value);
    formData.append("harga", this.materialForm.get("harga").value);
    formData.append("satuanId", this.materialForm.get("selectedSatuan").value);
    formData.append("gambar", this.materialForm.get("gambar").value);
    formData.append("urlGambar", this.materialForm.get("urlGambar").value);

    this.httpClient.put(environment.baseApiUrl.concat(this.pathUpdateUrl),
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
