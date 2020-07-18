import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { FullComponent } from "./layouts/full/full.component";

export const routes: Routes = [
  {
    path: "",
    redirectTo: "vehicle",
    pathMatch: "full",
  },
  {
    path: "vehicle",
    component: FullComponent,
    // canActivate: [NgxPermissionsGuard],
    loadChildren: () =>
      import("./modules/Vehicles/vehicles.module").then(
        (m) => m.VehiclesModule
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
