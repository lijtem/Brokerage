import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HouseFormComponent } from './house-form/house-form.component';

const routes: Routes = [
  {
    path: "new",
    component: HouseFormComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HousesRoutingModule { }
