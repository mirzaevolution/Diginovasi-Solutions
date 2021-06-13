import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Component, OnInit, Renderer2 } from '@angular/core';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { ObjectBaseResponse } from 'src/app/ObjectBaseResponse';
import { SalesOrderObject } from '../../SalesOrderResponse';
import * as moment from 'moment';
@Component({
  selector: 'app-list-sales-order',
  templateUrl: './list-sales-order.component.html',
  styleUrls: ['./list-sales-order.component.css']
})
export class ListSalesOrderComponent implements OnInit {

  public dtOptions: DataTables.Settings = { };
  private pathUrl: string = "api/SalesOrder/GetAll";
  private pathDeleteUrl: string = "api/SalesOrder/Delete/";
  constructor(private renderer2: Renderer2,
    private router: Router,
    private httpClient: HttpClient) { }

  ngOnInit(): void {
      this.dtOptions = {
        ajax: environment.baseApiUrl.concat(this.pathUrl),
        columns: [
          {
            data: "noSalesOrder"
          },
          {
            data: "tanggal",
            render:function(data:any, type: any, row: SalesOrderObject) {
              return moment(row.tanggal).format("YYYY-MM-DD");
            }
          },
          {
            data: "noCustomer"
          },
          {
            data: "namaCustomer"
          },
          {
            data: "total"
          },
          {
            render: function(data:any, type: any, row: SalesOrderObject) {
              return `<button class='btn btn-sm btn-secondary' salesorder-edit-id='${row.id}'><span salesorder-edit-id='${row.id}' class='fa fa-edit'></span> Edit</button> <button class='btn btn-sm btn-danger' salesorder-delete-id='${row.id}' salesorder-delete-name='${row.noSalesOrder}'><span salesorder-delete-id='${row.id}' salesorder-delete-name='${row.noSalesOrder}' class='fa fa-remove'></span> Delete</button>`;
            }
          }
        ]
      }
  }
  ngAfterViewInit(): void {
    this.renderer2.listen('document', 'click', (event) => {
      if (event.target.hasAttribute("salesorder-edit-id")) {
        this.router.navigate(["/sales-order/edit/" + event.target.getAttribute("salesorder-edit-id")]);
      } else if(event.target.hasAttribute("salesorder-delete-id")){

        Swal.fire({
          confirmButtonText: "Yes",
          cancelButtonText: "No",
          showCancelButton: true,
          title: "Konfirmasi",
          html: `Apakah anda yakin untuk menghapus ${event.target.getAttribute("salesorder-delete-name")} ?`,
          icon: "question"
        }).then(result => {
          if(result.value){
              this.httpClient
              .delete(environment.baseApiUrl.concat(this.pathDeleteUrl).concat(event.target.getAttribute("salesorder-delete-id")))
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
