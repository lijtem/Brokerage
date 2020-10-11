import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { VehicleService } from '../vehicle.service';
import { SaveVehicleModel, VehicleModel } from '../models/vehicle-model';
import * as _ from 'underscore';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/forkJoin';
import { ToastyService } from 'ng2-toasty';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit{
  makes: any;
  models: any[];
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

  // addressForm = this.fb.group({
  //   make: [null, Validators.required],
  //   model: [null, Validators.required],
  //   yearMade: null,
  //   color: null,
  //   transmission:null,
  //   engineType: null,
  //   engineSize: null,
  //   price:null,
  //   contact: [null, Validators.required],
  //   lastName: [null, Validators.required],
  //   address: [null, Validators.required],
  //   address2: null,
  //   city: [null, Validators.required],
  //   state: [null, Validators.required],
  //   postalCode: [null, Validators.compose([
  //     Validators.required, Validators.minLength(5), Validators.maxLength(5)])
  //   ],
  //   shipping: ['free', Validators.required]
  // });

  


  constructor(   
    private vehicleService: VehicleService,
    private route: ActivatedRoute,
    private router: Router,
    private toastyService: ToastyService
    ) {}

  ngOnInit(): void {
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
        //this.setVehicle(data[2]);
        this.populateModels();
      }
    }, err => {
      if (err.status == 404)
        this.router.navigate(['/home']);
    });
  }

  
  private setVehicle(v: VehicleModel) {
    this.vehicle.id = v.id;
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;
    this.vehicle.IsOwner = v.isOwner;
    this.vehicle.contact = v.contact;
    this.vehicle.features = _.pluck(v.features, 'id');
  }

  onMakeChange() {
    this.populateModels();
    delete this.vehicle.modelId;
  }

  private populateModels() {
   
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
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

  onSubmit() {
    var x: number = this.vehicle.modelId
    this.vehicle.modelId = x;

    this.vehicleService.create(this.vehicle)
        .subscribe(x => {

          this.toastyService.success({
            title: 'Success',
            msg: 'The vehicle was sucessfully updated.',
            theme: 'bootstrap',
            showClose: true,
            timeout: 5000
          });
          this.router.navigate(['/vehicle/list']);
        });
      }

      cancle(){
        this.router.navigate(['/vehicle']);
      }
    
     
}
