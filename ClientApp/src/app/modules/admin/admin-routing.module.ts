import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ManageLocationComponent } from './manage-location/manage-location.component';

const routes: Routes = [{
  path: '',
  redirectTo: 'manage-location'
},{
  path: 'manage-location',
  component: ManageLocationComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
