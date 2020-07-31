import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HouseService } from '../house.service';
import { Router } from '@angular/router';
import { ToastyService } from 'ng2-toasty';
import { SaveHouseModel } from '../models/house-model';

@Component({
  selector: 'app-house-form',
  templateUrl: './house-form.component.html',
  styleUrls: ['./house-form.component.css']
})
export class HouseFormComponent implements OnInit {
  cities: any;
  locations: any[];
  houseForm = this.fb.group({
    title: [null],
    description: [null],
    category: null,
    propertyFor: ['Sale'],
    city: [2],
    location: [null],
    price: [null],
    bedrooms: [0],
    bathrooms: [0],
    area: [0],
    noFloors: [0],
    name: [null],
    email: [null],
    phone: [null],
    code: [null],
    isOwner: [true],
  });
  house: SaveHouseModel = {} as SaveHouseModel;
  



  constructor(private fb: FormBuilder,
    private houseService: HouseService,
    private router: Router,
    private toastyService: ToastyService) { }
  ngOnInit(): void {
    this.houseService.getLocations().subscribe(dt => {
      this.cities = dt;
      this.populateLocation();
    })
   
  }

  onSubmit() {
    if(this.houseForm.valid){
      this.house.title = this.houseForm.controls.title.value;
      this.house.description = this.houseForm.controls.description.value;
      this.house.category = this.houseForm.controls.category.value;
      this.house.propertyFor = this.houseForm.controls.propertyFor.value;
      this.house.cityId = this.houseForm.controls.city.value;
      this.house.locationId = this.houseForm.controls.location.value;      
      this.house.noFloors = this.houseForm.controls.noFloors.value;      
      this.house.bathrooms = this.houseForm.controls.bathrooms.value;          
      this.house.bedrooms = this.houseForm.controls.bedrooms.value;      
      this.house.area = this.houseForm.controls.area.value;          
      this.house.price = this.houseForm.controls.price.value;      
      this.house.code = this.houseForm.controls.code.value;  
      this.house.isOwner = this.houseForm.controls.isOwner.value;; 
      this.house.contact  =  {
        name: this.houseForm.controls.name.value,
        phone: this.houseForm.controls.phone.value,
        email: this.houseForm.controls.email.value
      }       
    }

    this.houseService.create(this.house).subscribe(
      res => {
        this.toastyService.success({
          title: 'Success',
          msg: 'The house was sucessfully added.',
          theme: 'bootstrap',
          showClose: true,
          timeout: 5000
        });
        this.router.navigate(['/house/list']);
      }
    );
  }

  onCityChange() {
    this.populateLocation();
  }
  populateLocation() {
    var selectedLocation = this.cities.find(m => m.id == this.houseForm.controls.city.value);
    this.locations = selectedLocation ? selectedLocation.locations : [];
  }

  cancel(){
    this.router.navigate(['/house/list']);
  }
}
