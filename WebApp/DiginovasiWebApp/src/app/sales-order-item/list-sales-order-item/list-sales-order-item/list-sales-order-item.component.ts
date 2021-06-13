import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Component, OnInit, Renderer2 } from '@angular/core';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { ObjectBaseResponse } from 'src/app/ObjectBaseResponse';
import { SalesOrderItemObject } from '../../SalesOrderItemResponse';

@Component({
  selector: 'app-list-sales-order-item',
  templateUrl: './list-sales-order-item.component.html',
  styleUrls: ['./list-sales-order-item.component.css']
})
export class ListSalesOrderItemComponent implements OnInit {


  public dtOptions: DataTables.Settings = { };
  private pathUrl: string = "api/SalesOrderItem/GetAll";
  private pathDeleteUrl: string = "api/SalesOrderItem/Delete/";
  constructor(private renderer2: Renderer2, private router: Router, private httpClient: HttpClient) { }

  ngOnInit(): void {
      this.dtOptions = {
        ajax: environment.baseApiUrl.concat(this.pathUrl),
        scrollX:true,
        columns: [
          {
            data: "id"
          },
          {
            data: "noSalesOrder"
          },
          {
            data: "kodeMaterial"
          },
          {
            data: "deskripsiMaterial"
          },
          {
            data: "jumlah"
          },
          {
            data: "harga"
          },
          {
            data: "subTotal"
          },
          {
            data: "kodeSatuan"
          },
          {
            render: function(data:any, type: any, row: SalesOrderItemObject) {
              return `<button class='btn btn-sm btn-secondary' salesorderitem-edit-id='${row.id}'><span class='fa fa-edit'></span> Edit</button> <button class='btn btn-sm btn-danger' salesorderitem-delete-id='${row.id}' salesorderitem-delete-name='${row.id}'><span class='fa fa-remove'></span> Delete</button>`;
            }
          }
        ]
      }
  }
  ngAfterViewInit(): void {
    this.renderer2.listen('document', 'click', (event) => {
      if (event.target.hasAttribute("salesorderitem-edit-id")) {
        this.router.navigate(["/sales-order-item/edit/" + event.target.getAttribute("salesorderitem-edit-id")]);
      } else if(event.target.hasAttribute("salesorderitem-delete-id")){

        Swal.fire({
          confirmButtonText: "Yes",
          cancelButtonText: "No",
          showCancelButton: true,
          title: "Konfirmasi",
          html: `Apakah anda yakin untuk menghapus ${event.target.getAttribute("salesorderitem-delete-name")} ?`,
          icon: "question"
        }).then(result => {
          if(result.value){
              this.httpClient
              .delete(environment.baseApiUrl.concat(this.pathDeleteUrl).concat(event.target.getAttribute("salesorderitem-delete-id")))
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
