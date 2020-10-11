import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { AdminServices } from '../admin-services';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastyService } from 'ng2-toasty';
import { Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-manage-location',
  templateUrl: './manage-location.component.html',
  styleUrls: ['./manage-location.component.css']
})
export class ManageLocationComponent implements OnInit {
  dataSource = new MatTableDataSource<any>();
  dsLocation = new MatTableDataSource<any>();
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild('modulePage', { static: true }) modulePage: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  displayedColumns: string[] = ['id', 'name', 'action'];
  displayedModelColumns: string[] = ['id', 'name', 'action'];
  private readonly PAGE_SIZE = 8;

  cities: any;
  locations: any[];
  selectedCity: any = {};
  _city = {
    'id': 0,
    'name': ''    
  };

  constructor(private adminService: AdminServices,
    public dialog: MatDialog,    
    private toastyService: ToastyService) { }

  ngOnInit() {
    this.getCities();
    this.dataSource.paginator = this.paginator;
    this.dsLocation.paginator = this.modulePage;
  }

  private getCities() {
    this.adminService.getCities()
      .subscribe(dt => {
        this.cities = dt;
        this.dataSource.data = dt;
      });
  }

  getDetail(index) {
    this._city.id = index.id;
    this._city.name = index.name;
    this.selectedCity = this.cities.find(m => m.id == index.id);
    this.locations = this.selectedCity ? this.selectedCity.locations : [];
    this.dsLocation.data = this.locations;
  }

  editCity(element) {
    this.openDialog(element, 'Update');
  }
  deleteCity(element){
    this.openDialog(element,'Delete');
  }

  openDialog(city:any, opt?:string): void {
  
    const _data = {
      'id': city.id,
      'name': city.name,
      'operation': opt
    }
    const dialogRef = this.dialog.open(CityDialog, {
      width: '400px',
      data: _data
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != "") {
        switch (result.operation) {
          case 'New': {
            this.adminService.createCity(result).subscribe(dt =>{
              if(dt > 0){
                this.getCities();
                this.toastyService.success({
                  title: 'Success',
                  msg: 'The make was sucessfully added.',
                  theme: 'bootstrap',
                  showClose: true,
                  timeout: 5000
                });
               
              }
            });
            break;
          }
          case 'Update': {
            this.adminService.editCity(result).subscribe(dt =>{
              if(dt){
                this.getCities();
                this.toastyService.success({
                  title: 'Success',
                  msg: 'The make was sucessfully updated.',
                  theme: 'bootstrap',
                  showClose: true,
                  timeout: 5000
                });
               
              }
            });
            break;
          }
          case 'Delete': {
            this.adminService.deleteCity(result).subscribe(dt =>{
              if(dt){
                this.getCities();
                this.toastyService.success({
                  title: 'Success',
                  msg: 'The make was sucessfully deleted.',
                  theme: 'bootstrap',
                  showClose: true,
                  timeout: 5000
                });
               
              }
            }); 
            break;
          }

        }
      }
      //this.animal = result;
    });
  }

  openLocation(_model:any, opt:string){    
    const _data = {
      'cityId': this._city.id,
      'cityName': this._city.name,
      'location': _model,
      'operation': opt
    }
    const dialogRef = this.dialog.open(LocationsDialog, {
      width: '400px',
      data: _data
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result != "") {
        switch (result.operation) {
          case 'New': {
            this.adminService.createLocation(result).subscribe(dt =>{
              if(dt > 0){
                this.getCities();
                this.toastyService.success({
                  title: 'Success',
                  msg: 'The location was sucessfully added.',
                  theme: 'bootstrap',
                  showClose: true,
                  timeout: 5000
                });
               
              }
            });
            break;
          }
          case 'Update': {
            this.adminService.editLocation(result).subscribe(dt =>{
              if(dt){
                this.getCities();
                this.toastyService.success({
                  title: 'Success',
                  msg: 'The location was sucessfully updated.',
                  theme: 'bootstrap',
                  showClose: true,
                  timeout: 5000
                });
               
              }
            });
            break;
          }
          case 'Delete': {
            this.adminService.deleteLocation(result).subscribe(dt =>{
              if(dt){
                this.getCities();
                this.toastyService.success({
                  title: 'Success',
                  msg: 'The location was sucessfully deleted.',
                  theme: 'bootstrap',
                  showClose: true,
                  timeout: 5000
                });
               
              }
            }); 
            break;
          }

        }
      }
    });
  }
  editLocation(element){
    this.openLocation(element,'Update')
  }
  deleteLocation(element){
    this.openLocation(element,'Delete')
  }
  
  

}

@Component({
  selector: 'city-dialog',
  templateUrl: 'city-dialog.html',
})
export class CityDialog implements OnInit {
  cityForm = this.formBuilder.group({
    name: [null, [Validators.required]],
    id: [null]
  });
  opr = {
    "operation": '',
    "id": 0,
    "name": '',
  }
  constructor(
    public dialogRef: MatDialogRef<CityDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder) {

  }
  ngOnInit(): void {
    if (this.data != null || JSON.stringify(this.data) != '{}') {
      this.cityForm.controls.name.patchValue(this.data.name);
      this.cityForm.controls.id.patchValue(this.data.id);
    }

  }
  onNoClick(): void {
    this.dialogRef.close('');
  }
  onSave() {
    this.opr.operation = 'New';
    this.opr.id = 0;
    this.opr.name = this.cityForm.controls.name.value;
    this.dialogRef.close(this.opr);
  }
  onUpdate() {
    this.opr.operation = 'Update';
    this.opr.id = this.cityForm.controls.id.value;
    this.opr.name = this.cityForm.controls.name.value;
    this.dialogRef.close(this.opr);
  }
  onDelete() {
    this.opr.operation = 'Delete';
    this.opr.id = this.cityForm.controls.id.value;
    this.opr.name = this.cityForm.controls.name.value;
    this.dialogRef.close(this.opr);
  }

}


@Component({
  selector: 'location-dialog',
  templateUrl: 'location-dialog.html',
})
export class LocationsDialog implements OnInit {
  locationForm = this.formBuilder.group({
    name: [null, [Validators.required]],
    id: [null],
    cityId:[null]
  });
  opr = {
    "operation": '',
    "id": 0,
    "name": '',
    "cityId":'',
  }
  constructor(
    public dialogRef: MatDialogRef<LocationsDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder) {

  }
  ngOnInit(): void {
    if(this.data != null && JSON.stringify(this.data) != '{}' && this.data.operation != 'New'){
      this.locationForm.controls.name.patchValue(this.data.location.name);
      this.locationForm.controls.id.patchValue(this.data.location.id);
      this.locationForm.controls.cityId.patchValue(this.data.cityId);
    }else{
      this.locationForm.controls.cityId.patchValue(this.data.cityId);
    }

  }
  onNoClick(): void {
    this.dialogRef.close('');
  }
  onSave() {
    this.opr.operation = 'New';
    this.opr.id = 0;
    this.opr.name = this.locationForm.controls.name.value;
    this.opr.cityId = this.locationForm.controls.cityId.value;
    this.dialogRef.close(this.opr);
  }
  onUpdate() {
    this.opr.operation = 'Update';
    this.opr.id = this.locationForm.controls.id.value;
    this.opr.name = this.locationForm.controls.name.value;
    this.opr.cityId = this.locationForm.controls.cityId.value;
    this.dialogRef.close(this.opr);
  }
  onDelete() {
    this.opr.operation = 'Delete';
    this.opr.id = this.locationForm.controls.id.value;
    this.opr.name = this.locationForm.controls.name.value;
    this.opr.cityId = this.locationForm.controls.cityId.value;
    this.dialogRef.close(this.opr);
  }

}