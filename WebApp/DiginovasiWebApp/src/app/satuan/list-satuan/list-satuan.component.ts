import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Component, OnInit, Renderer2 } from '@angular/core';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { SatuanObject } from '../SatuanResponse';
import { ObjectBaseResponse } from 'src/app/ObjectBaseResponse';

@Component({
  selector: 'app-list-satuan',
  templateUrl: './list-satuan.component.html',
  styleUrls: ['./list-satuan.component.css']
})
export class ListSatuanComponent implements OnInit {

  public dtOptions: DataTables.Settings = { };
  private pathUrl: string = "api/Satuan/GetAll";
  private pathDeleteUrl: string = "api/Satuan/Delete/";
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
            render: function(data:any, type: any, row: SatuanObject) {
              return `<button class='btn btn-sm btn-secondary' satuan-edit-id='${row.id}'><span class='fa fa-edit'></span> Edit</button> <button class='btn btn-sm btn-danger' satuan-delete-id='${row.id}' satuan-delete-name='${row.kode}'><span class='fa fa-remove'></span> Delete</button>`;
            }
          }
        ]
      }
  }
  ngAfterViewInit(): void {
    this.renderer2.listen('document', 'click', (event) => {
      if (event.target.hasAttribute("satuan-edit-id")) {
        this.router.navigate(["/satuan/edit/" + event.target.getAttribute("satuan-edit-id")]);
      } else if(event.target.hasAttribute("satuan-delete-id")){

        Swal.fire({
          confirmButtonText: "Yes",
          cancelButtonText: "No",
          showCancelButton: true,
          title: "Konfirmasi",
          html: `Apakah anda yakin untuk menghapus ${event.target.getAttribute("satuan-delete-name")} ?`,
          icon: "question"
        }).then(result => {
          if(result.value){
              this.httpClient
              .delete(environment.baseApiUrl.concat(this.pathDeleteUrl).concat(event.target.getAttribute("satuan-delete-id")))
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
