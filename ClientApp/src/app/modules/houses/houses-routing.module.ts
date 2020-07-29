import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HouseFormComponent } from './house-form/house-form.component';
import { HouseListComponent } from './house-list/house-list.component';
import { HouseEditComponent } from './house-edit/house-edit.component';

const routes: Routes = [
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
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HousesRoutingModule { }
