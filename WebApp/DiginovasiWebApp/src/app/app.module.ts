import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DataTablesModule } from 'angular-datatables';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ListSatuanComponent } from './satuan/list-satuan/list-satuan.component';
import { AddSatuanComponent } from './satuan/add-satuan/add-satuan.component';
import { EditSatuanComponent } from './satuan/edit-satuan/edit-satuan.component';
import { ListCustomerComponent } from './customer/list-customer/list-customer.component';
import { AddCustomerComponent } from './customer/add-customer/add-customer.component';
import { EditCustomerComponent } from './customer/edit-customer/edit-customer.component';
import { ListMaterialComponent } from './material/list-material/list-material.component';
import { AddMaterialComponent } from './material/add-material/add-material.component';
import { EditMaterialComponent } from './material/edit-material/edit-material.component';
import { HttpClientModule } from '@angular/common/http';
import { AddSalesOrderComponent } from './sales-order/add-sales-order/add-sales-order/add-sales-order.component';
import { EditSalesOrderComponent } from './sales-order/edit-sales-order/edit-sales-order/edit-sales-order.component';
import { ListSalesOrderComponent } from './sales-order/list-sales-order/list-sales-order/list-sales-order.component';
import { ListSalesOrderItemComponent } from './sales-order-item/list-sales-order-item/list-sales-order-item/list-sales-order-item.component';
import { AddSalesOrderItemComponent } from './sales-order-item/add-sales-order-item/add-sales-order-item/add-sales-order-item.component';
import { EditSalesOrderItemComponent } from './sales-order-item/edit-sales-order-item/edit-sales-order-item/edit-sales-order-item.component';

@NgModule({
  declarations: [
    AppComponent,
    ListSatuanComponent,
    AddSatuanComponent,
    EditSatuanComponent,
    ListCustomerComponent,
    AddCustomerComponent,
    EditCustomerComponent,
    ListMaterialComponent,
    AddMaterialComponent,
    EditMaterialComponent,
    AddSalesOrderComponent,
    EditSalesOrderComponent,
    ListSalesOrderComponent,
    ListSalesOrderItemComponent,
    AddSalesOrderItemComponent,
    EditSalesOrderItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    DataTablesModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
