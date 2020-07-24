import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VehicleFormComponent } from './vehicle-form/vehicle-form.component';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { VehicleEditComponent } from './vehicle-edit/vehicle-edit.component';

const routes: Routes = [
  {
    path: "",
    redirectTo: "list",
  },
  {
    path: "new",
    component: VehicleFormComponent,
  },
  {
    path: "list",
    component: VehicleListComponent,
  },
  { path: 'edit/:id', component: VehicleEditComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class VehiclesRoutingModule { }