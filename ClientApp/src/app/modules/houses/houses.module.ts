import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HousesRoutingModule } from './houses-routing.module';
import { HouseFormComponent } from './house-form/house-form.component';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatCardModule } from '@angular/material/card';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HouseListComponent } from './house-list/house-list.component';
import { MatTableModule } from '@angular/material/table';
import { HouseEditComponent } from './house-edit/house-edit.component';
import { PaginationComponent } from 'src/app/shared/pagination.component';

@NgModule({
  declarations: [HouseFormComponent, HouseListComponent, HouseEditComponent, PaginationComponent],
  imports: [
    CommonModule,
    HousesRoutingModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatRadioModule,
    MatCardModule,
    ReactiveFormsModule,
    MatTableModule,
    FormsModule,
  ]
})
export class HousesModule { }
