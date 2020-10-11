import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VehiclesRoutingModule } from './vehicles-routing.module';
import { VehicleFormComponent } from './vehicle-form/vehicle-form.component';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatCardModule } from '@angular/material/card';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { VehicleEditComponent } from './vehicle-edit/vehicle-edit.component';
import {MatTabsModule} from '@angular/material/tabs';
import { SharedModule } from 'src/app/shared/shared.module';
import { VehicleMakesComponent, MakeDialog, ModelDialog } from './vehicle-makes/vehicle-makes.component';
import {MatDialogModule} from '@angular/material/dialog';
import { RemarkDialog, VehicleDetailComponent } from './vehicle-detail/vehicle-detail.component';

@NgModule({
  declarations: [VehicleFormComponent, VehicleListComponent, VehicleEditComponent, VehicleMakesComponent, MakeDialog, ModelDialog, VehicleDetailComponent, RemarkDialog],
  imports: [
    CommonModule,
    VehiclesRoutingModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatRadioModule,
    MatCardModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatTabsModule,
    MatDialogModule,
    SharedModule
  ],
  entryComponents: [MakeDialog, ModelDialog,RemarkDialog]
})
export class VehiclesModule { }
