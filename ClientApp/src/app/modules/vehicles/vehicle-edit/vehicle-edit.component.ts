import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleService } from '../vehicle.service';
import { ToastyService } from 'ng2-toasty';
import { SaveVehicleModel, VehicleModel } from '../models/vehicle-model';
import { Observable } from 'rxjs';
import * as _ from 'underscore';
import { PhotoService } from '../photo.service';

@Component({
  selector: 'app-vehicle-edit',
  templateUrl: './vehicle-edit.component.html',
  styleUrls: ['./vehicle-edit.component.css']
})
export class VehicleEditComponent implements OnInit {
 @ViewChild('fileInput', {static: false}) fileInput: ElementRef;
  makes: any;
  models: any[];
  photos: any[];
  features: any;
  vehicle: SaveVehicleModel = {
    modelId: 0,
    IsOwner: false,
    features: [],
    contact: {
      name: '',
      email: '',
      phone: '',
    },
  yearMade: null,
  color: '',
  transmission:'Automatic',
  engineType: 'Benzine',
  engineSize: '',
  price: '',

  };

  constructor(private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService,
    private toastyService: ToastyService,
    private photoService: PhotoService) {
      route.params.subscribe(p => {
        this.vehicle.id = +p['id'];
      });
     }

  ngOnInit() {
    var sources = [
      this.vehicleService.getMakes(),
      this.vehicleService.getFeatures(),
    ];

    if (this.vehicle.id)
      sources.push(this.vehicleService.getVehicle(this.vehicle.id));

    Observable.forkJoin(sources).subscribe(data => {
      this.makes = data[0];
      this.features = data[1];

      if (this.vehicle.id) {
        this.setVehicle(data[2]);
        this.populateModels();
      }
    }, err => {
      if (err.status == 404)
        this.router.navigate(['/vehicle']);
    });
  }

  private setVehicle(v: VehicleModel) {   
    this.vehicle.id = v.id;
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;
    this.vehicle.IsOwner = v.isOwner;
    this.vehicle.contact = v.contact;
    this.vehicle.features = _.pluck(v.features, 'id');
    this.vehicle.yearMade = v.yearMade;
    this.vehicle.price = v.price;
    this.vehicle.color = v.color;
    this.vehicle.engineSize = v.engineSize;
    this.vehicle.engineType = v.engineType;
    this.vehicle.transmission = v.transmission;
    this.photos= v.photos;
  }

  onMakeChange() {
    this.populateModels();

    delete this.vehicle.modelId;
  }

  private populateModels() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
  }

  onSubmit() {
    var x: number = this.vehicle.modelId
    this.vehicle.modelId = x;

    if (this.vehicle.id) {
      this.vehicleService.update(this.vehicle)
        .subscribe(x => {
          this.toastyService.success({
            title: 'success',
            msg: 'The vehicle was sucessfully updated.',
            theme: 'bootstrap',
            showClose: true,
            timeout: 5000
          });
          this.router.navigate(['/vehicle/list']);
        });
    }
  }

  onFeatureToggle(featureId, $event) {
    if ($event.target.checked)
      this.vehicle.features.push(featureId);
    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  onOwnerToggle($event){
    if ($event.target.checked)
      this.vehicle.IsOwner = true;
    else
      this.vehicle.IsOwner = false
  }

  uploadPhoto(){
    var nativeEl: HTMLInputElement = this.fileInput.nativeElement;
    this.photoService.upload(this.vehicle.id,nativeEl.files[0]).subscribe(
      dt => {
        this.photos.push(dt);
      }
    )
  }

}
