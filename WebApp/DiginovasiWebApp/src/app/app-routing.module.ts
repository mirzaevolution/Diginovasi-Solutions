import { EditSalesOrderComponent } from './sales-order/edit-sales-order/edit-sales-order/edit-sales-order.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCustomerComponent } from './customer/add-customer/add-customer.component';
import { EditCustomerComponent } from './customer/edit-customer/edit-customer.component';
import { ListCustomerComponent } from './customer/list-customer/list-customer.component';
import { AddMaterialComponent } from './material/add-material/add-material.component';
import { EditMaterialComponent } from './material/edit-material/edit-material.component';
import { ListMaterialComponent } from './material/list-material/list-material.component';
import { AddSalesOrderComponent } from './sales-order/add-sales-order/add-sales-order/add-sales-order.component';
import { ListSalesOrderComponent } from './sales-order/list-sales-order/list-sales-order/list-sales-order.component';
import { AddSatuanComponent } from './satuan/add-satuan/add-satuan.component';
import { EditSatuanComponent } from './satuan/edit-satuan/edit-satuan.component';
import { ListSatuanComponent } from './satuan/list-satuan/list-satuan.component';
import { ListSalesOrderItemComponent } from './sales-order-item/list-sales-order-item/list-sales-order-item/list-sales-order-item.component';
import { AddSalesOrderItemComponent } from './sales-order-item/add-sales-order-item/add-sales-order-item/add-sales-order-item.component';
import { EditSalesOrderItemComponent } from './sales-order-item/edit-sales-order-item/edit-sales-order-item/edit-sales-order-item.component';

const routes: Routes = [
  { path: "customer/list", component:ListCustomerComponent },
  { path: "customer/add", component: AddCustomerComponent },
  { path: "customer/edit/:id", component: EditCustomerComponent},

  { path: "satuan/list", component:ListSatuanComponent },
  { path: "satuan/add", component: AddSatuanComponent },
  { path: "satuan/edit/:id", component: EditSatuanComponent},

  { path: "material/list", component: ListMaterialComponent },
  { path: "material/add", component: AddMaterialComponent },
  { path: "material/edit/:id", component: EditMaterialComponent},

  { path: "sales-order/list", component: ListSalesOrderComponent },
  { path: "sales-order/add", component: AddSalesOrderComponent },
  { path: "sales-order/edit/:id", component: EditSalesOrderComponent},

  { path: "sales-order-item/list", component: ListSalesOrderItemComponent },
  { path: "sales-order-item/add", component: AddSalesOrderItemComponent },
  { path: "sales-order-item/edit/:id", component: EditSalesOrderItemComponent},

  { path: "", component: ListCustomerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
