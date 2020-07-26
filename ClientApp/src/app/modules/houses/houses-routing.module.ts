import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HouseFormComponent } from './house-form/house-form.component';
import { HouseListComponent } from './house-list/house-list.component';

const routes: Routes = [
  {
    path: "new",
    component: HouseFormComponent,
  },
  {
    path: "list",
    component: HouseListComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HousesRoutingModule { }
