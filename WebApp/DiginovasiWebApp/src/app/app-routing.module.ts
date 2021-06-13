import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCustomerComponent } from './customer/add-customer/add-customer.component';
import { EditCustomerComponent } from './customer/edit-customer/edit-customer.component';
import { ListCustomerComponent } from './customer/list-customer/list-customer.component';
import { AddMaterialComponent } from './material/add-material/add-material.component';
import { EditMaterialComponent } from './material/edit-material/edit-material.component';
import { ListMaterialComponent } from './material/list-material/list-material.component';
import { AddSatuanComponent } from './satuan/add-satuan/add-satuan.component';
import { EditSatuanComponent } from './satuan/edit-satuan/edit-satuan.component';
import { ListSatuanComponent } from './satuan/list-satuan/list-satuan.component';

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

  { path: "", component: ListCustomerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }