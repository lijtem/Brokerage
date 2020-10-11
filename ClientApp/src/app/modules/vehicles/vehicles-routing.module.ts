import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VehicleFormComponent } from './vehicle-form/vehicle-form.component';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { VehicleEditComponent } from './vehicle-edit/vehicle-edit.component';
import { VehicleMakesComponent } from './vehicle-makes/vehicle-makes.component';
import { VehicleDetailComponent } from './vehicle-detail/vehicle-detail.component';

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
  {
    path: "makes",
    component: VehicleMakesComponent,
  },
  { path: 'edit/:id', component: VehicleEditComponent },
  { path: 'detail/:id', component: VehicleDetailComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class VehiclesRoutingModule { }
