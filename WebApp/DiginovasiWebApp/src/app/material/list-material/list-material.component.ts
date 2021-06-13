import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Component, OnInit, Renderer2 } from '@angular/core';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { ObjectBaseResponse } from 'src/app/ObjectBaseResponse';
import { MaterialObject } from '../MaterialResponse';
@Component({
  selector: 'app-list-material',
  templateUrl: './list-material.component.html',
  styleUrls: ['./list-material.component.css']
})
export class ListMaterialComponent implements OnInit {

  public dtOptions: DataTables.Settings = { };
  private pathUrl: string = "api/Material/GetAll";
  private pathDeleteUrl: string = "api/Material/Delete/";
  constructor(private renderer2: Renderer2, private router: Router, private httpClient: HttpClient) { }

  ngOnInit(): void {
      this.dtOptions = {
        ajax: environment.baseApiUrl.concat(this.pathUrl),
        columns: [
          {
            data: "kode"
          },
          {
            data: "deskripsi"
          },
          {
            data: "harga"
          },
          {
            render: function(data:any, type:any, row: MaterialObject){
              return `<img src='${environment.baseApiUrl}${row.formattedUrlGambar}' style='height:100px;' class='img-responsive'/>`;
            }
          },
          {
            render: function(data:any, type: any, row: MaterialObject) {
              return `<button class='btn btn-sm btn-secondary' material-edit-id='${row.id}'><span material-edit-id='${row.id}' class='fa fa-edit'></span> Edit</button> <button class='btn btn-sm btn-danger' material-delete-id='${row.id}' material-delete-name='${row.kode}'><span material-delete-id='${row.id}' material-delete-name='${row.kode}' class='fa fa-remove'></span> Delete</button>`;
            }
          }
        ]
      }
  }
  ngAfterViewInit(): void {
    this.renderer2.listen('document', 'click', (event) => {
      if (event.target.hasAttribute("material-edit-id")) {
        this.router.navigate(["/material/edit/" + event.target.getAttribute("material-edit-id")]);
      } else if(event.target.hasAttribute("material-delete-id")){

        Swal.fire({
          confirmButtonText: "Yes",
          cancelButtonText: "No",
          showCancelButton: true,
          title: "Konfirmasi",
          html: `Apakah anda yakin untuk menghapus ${event.target.getAttribute("material-delete-name")} ?`,
          icon: "question"
        }).then(result => {
          if(result.value){
              this.httpClient
              .delete(environment.baseApiUrl.concat(this.pathDeleteUrl).concat(event.target.getAttribute("material-delete-id")))
              .subscribe((result:ObjectBaseResponse) => {
                if(result.success){
                  Swal.fire("Sukses", result.message, "success");
                  window.location.reload();
                } else {
                  Swal.fire("Gagal", result.message, "error");
                }
              })
          }
        })
      }
    });
  }

}
