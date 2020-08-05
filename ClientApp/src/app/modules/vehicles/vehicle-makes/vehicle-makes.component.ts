import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { VehicleService } from '../vehicle.service';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { JsonpInterceptor } from '@angular/common/http';
import { ToastyService } from 'ng2-toasty';

@Component({
  selector: 'app-vehicle-makes',
  templateUrl: './vehicle-makes.component.html',
  styleUrls: ['./vehicle-makes.component.css']
})
export class VehicleMakesComponent implements OnInit {
  dataSource = new MatTableDataSource<any>();
  dataSourceModel = new MatTableDataSource<any>();
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild('modulePage', { static: true }) modulePage: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  displayedColumns: string[] = ['id', 'name', 'action'];
  displayedModelColumns: string[] = ['id', 'name', 'action'];

  private readonly PAGE_SIZE = 8;

  makes: any;
  models: any[];
  selectedMake: any = {};
  _make = {
    'id': 0,
    'name': ''    
  };
  constructor(private vehicleService: VehicleService,
    public dialog: MatDialog,    
    private toastyService: ToastyService) { }

  ngOnInit() {
    this.getMakes();
    this.dataSource.paginator = this.paginator;
    this.dataSourceModel.paginator = this.modulePage;
  }

  private getMakes() {
    this.vehicleService.getMakes()
      .subscribe(makes => {
        this.makes = makes;
        this.dataSource.data = makes;
      });
  }

  getDetail(index) {
    this._make.id = index.id;
    this._make.name = index.name;
    this.selectedMake = this.makes.find(m => m.id == index.id);
    this.models = this.selectedMake ? this.selectedMake.models : [];
    this.dataSourceModel.data = this.models;
  }

  openDialog(make:any, opt?:string): void {
    const _data = {
      'id': make.id,
      'name': make.name,
      'operation': opt
    }
    const dialogRef = this.dialog.open(MakeDialog, {
      width: '400px',
      data: _data
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != "") {
        switch (result.operation) {
          case 'New': {
            this.vehicleService.createMake(result).subscribe(dt =>{
              if(dt > 0){
                this.getMakes();
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
            this.vehicleService.editMake(result).subscribe(dt =>{
              if(dt){
                this.getMakes();
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
            this.vehicleService.deleteMake(result).subscribe(dt =>{
              if(dt){
                this.getMakes();
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
  editMake(element) {
    this.openDialog(element, 'Update');
  }
  deleteMake(element){
    this.openDialog(element,'Delete');
  }
  newModel(){
    console.log(this._make);
  }

}

@Component({
  selector: 'make-dialog',
  templateUrl: 'make-dialog.html',
})
export class MakeDialog implements OnInit {
  makeForm = this.formBuilder.group({
    name: [null, [Validators.required]],
    id: [null]
  });
  opr = {
    "operation": '',
    "id": 0,
    "name": '',
  }
  constructor(
    public dialogRef: MatDialogRef<MakeDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder) {

  }
  ngOnInit(): void {
    if (this.data != null || JSON.stringify(this.data) != '{}') {
      this.makeForm.controls.name.patchValue(this.data.name);
      this.makeForm.controls.id.patchValue(this.data.id);
    }

  }
  onNoClick(): void {
    this.dialogRef.close('');
  }
  onSave() {
    this.opr.operation = 'New';
    this.opr.id = 0;
    this.opr.name = this.makeForm.controls.name.value;
    this.dialogRef.close(this.opr);
  }
  onUpdate() {
    this.opr.operation = 'Update';
    this.opr.id = this.makeForm.controls.id.value;
    this.opr.name = this.makeForm.controls.name.value;
    this.dialogRef.close(this.opr);
  }
  onDelete() {
    this.opr.operation = 'Delete';
    this.opr.id = this.makeForm.controls.id.value;
    this.opr.name = this.makeForm.controls.name.value;
    this.dialogRef.close(this.opr);
  }

}