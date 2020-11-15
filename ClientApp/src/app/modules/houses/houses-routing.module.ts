import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HouseFormComponent } from './house-form/house-form.component';
import { HouseListComponent } from './house-list/house-list.component';
import { HouseEditComponent } from './house-edit/house-edit.component';
import { HouseDetailComponent } from './house-detail/house-detail.component';

const routes: Routes = [
  {
    path: "",
    redirectTo: "list",
  },
  {
    path: "new",
    component: HouseFormComponent,
  },
  {
    path: "list",
    component: HouseListComponent,
  },
  {
    path: "edit/:id",
    component: HouseEditComponent,
  },
  { path: 'detail/:id', component: HouseDetailComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HousesRoutingModule { }
