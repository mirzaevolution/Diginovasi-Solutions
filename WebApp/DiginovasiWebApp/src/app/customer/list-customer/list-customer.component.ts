import { ObjectBaseResponse } from 'src/app/ObjectBaseResponse';
import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, OnInit, Renderer2 } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { CustomerObject } from '../CustomerResponse';

@Component({
  selector: 'app-list-customer',
  templateUrl: './list-customer.component.html',
  styleUrls: ['./list-customer.component.css']
})
export class ListCustomerComponent implements OnInit, AfterViewInit {
  public dtOptions: DataTables.Settings = { };
  private pathUrl: string = "api/Customer/GetAll";
  private pathDeleteUrl: string = "api/Customer/Delete/";
  constructor(private renderer2: Renderer2, private router: Router, private httpClient: HttpClient) { }

  ngOnInit(): void {
      this.dtOptions = {
        ajax: environment.baseApiUrl.concat(this.pathUrl),
        columns: [
          {
            data: "noCustomer"
          },
          {
            data: "nama"
          },
          {
            data: "noKontak"
          },
          {
            render: function(data:any, type: any, row: CustomerObject) {
              return `<button class='btn btn-sm btn-secondary' customer-edit-id='${row.id}'><span customer-edit-id='${row.id}' class='fa fa-edit'></span> Edit</button> <button class='btn btn-sm btn-danger' customer-delete-id='${row.id}' customer-delete-name='${row.nama}'><span customer-delete-id='${row.id}' customer-delete-name='${row.nama}' class='fa fa-remove'></span> Delete</button>`;
            }
          }
        ]
      }
  }
  ngAfterViewInit(): void {
    this.renderer2.listen('document', 'click', (event) => {
      if (event.target.hasAttribute("customer-edit-id")) {
        this.router.navigate(["/customer/edit/" + event.target.getAttribute("customer-edit-id")]);
      } else if(event.target.hasAttribute("customer-delete-id")){

        Swal.fire({
          confirmButtonText: "Yes",
          cancelButtonText: "No",
          showCancelButton: true,
          title: "Konfirmasi",
          html: `Apakah anda yakin untuk menghapus ${event.target.getAttribute("customer-delete-name")} ?`,
          icon: "question"
        }).then(result => {
          if(result.value){
              this.httpClient
              .delete(environment.baseApiUrl.concat(this.pathDeleteUrl).concat(event.target.getAttribute("customer-delete-id")))
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
