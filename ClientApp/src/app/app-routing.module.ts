import { NgModule, Component } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { FullComponent } from "./layouts/full/full.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { AuthorizeGuard } from "src/api-authorization/authorize.guard";

export const routes: Routes = [
  {
    path: "",
    redirectTo: "vehicle",
    pathMatch: "full",
  },
  {
    path: "vehicle",
    component: FullComponent,
    canActivate: [AuthorizeGuard],
    // canActivate: [NgxPermissionsGuard],
    loadChildren: () =>
      import("./modules/Vehicles/vehicles.module").then(
        (m) => m.VehiclesModule
      ),
  },
  {
    path: "house",
    component: FullComponent,    
    canActivate: [AuthorizeGuard],
    // canActivate: [NgxPermissionsGuard],
    loadChildren: () =>
      import("./modules/houses/houses.module").then(
        (m) => m.HousesModule
      ),
  },{
    path: "fetch",
    component: FetchDataComponent,
    canActivate: [AuthorizeGuard]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
