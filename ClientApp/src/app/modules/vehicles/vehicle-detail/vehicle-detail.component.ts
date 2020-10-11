import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleService } from '../vehicle.service';
import { PhotoService } from '../photo.service';
import { SaveVehicleModel, VehicleModel } from '../models/vehicle-model';
import { Observable } from 'rxjs';
import * as _ from 'underscore';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ToastyService } from 'ng2-toasty';

@Component({
  selector: 'app-vehicle-detail',
  templateUrl: './vehicle-detail.component.html',
  styleUrls: ['./vehicle-detail.component.css']
})
export class VehicleDetailComponent implements OnInit {
  
  vehicle: any;
  vehicleId: number;
  
  constructor(private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService,
    public dialog: MatDialog,        
    private toastyService: ToastyService,
    private photoService: PhotoService) {
      route.params.subscribe(p => {
        this.vehicleId = +p['id'];
      });
     }

  ngOnInit() {
   
    if (this.vehicleId){
      this.vehicleService.getVehicle(this.vehicleId).subscribe(
        dt => {
          this.vehicle = dt
        }, err => {
          if (err.status == 404)
            this.router.navigate(['/vehicle']);
        }
      )
    }
  } 

  openDialog(){
    const dialogRef = this.dialog.open(RemarkDialog, {
      width: '400px',
      data: this.vehicleId
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result != "") {
        this.vehicleService.addRemark(result).subscribe(dt => {
          if(dt > 0){
            this.toastyService.success({
              title: 'success',
              msg: 'remark sucessfully added.',
              theme: 'bootstrap',
              showClose: true,
              timeout: 5000
            });
          }
        })
      }
    });
  }
}


@Component({
  selector: 'remark-dialog',
  templateUrl: 'remark-dialog.html',
})
export class RemarkDialog implements OnInit {
  remarkForm = this.formBuilder.group({
    name: [null, [Validators.required]],
    phone: [null],
    remarks:[null],
    VehicleId:[null]
  });

  constructor(
    public dialogRef: MatDialogRef<RemarkDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder) {

  }
  ngOnInit(): void {
    if(this.data != null && JSON.stringify(this.data) != '{}' ){    
      this.remarkForm.controls.VehicleId.patchValue(this.data);
    }

  }
  onNoClick(): void {
    this.dialogRef.close('');
  }
  onSave() {
    const param = {
      Name:this.remarkForm.controls.name.value,
      Phone: this.remarkForm.controls.phone.value,
      Remarks: this.remarkForm.controls.remarks.value,
      VehicleId: this.remarkForm.controls.VehicleId.value
  }
    this.dialogRef.close(param);
  }
 

}
