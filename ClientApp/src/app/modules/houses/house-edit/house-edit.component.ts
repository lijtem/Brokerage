import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { HouseService } from '../house.service';
import { SaveHouseModel } from '../models/house-model';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastyService } from 'ng2-toasty';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-house-edit',
  templateUrl: './house-edit.component.html',
  styleUrls: ['./house-edit.component.css']
})
export class HouseEditComponent implements OnInit {
  cities: any;
  locations: any[];
  houseForm = this.fb.group({
    title: [null],
    description: [null],
    category: null,
    propertyFor: ['Sale'],
    city: [null],
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
  house: any = {} as any;
  constructor(private fb: FormBuilder,
    private houseService: HouseService,
    private router: Router,
    private route: ActivatedRoute,
    private toastyService: ToastyService) { 
      route.params.subscribe(p => {
        this.house.id = +p['id'];
      });
    }

  ngOnInit() {
    // var sources = [
    //   this.houseService.getLocations(),
    //   this.houseService.getHouse(this.house.id)
    // ]
    // Observable.forkJoin(sources).subscribe(data => {
    //   this.cities = data[0];     
    //   this.house = data[1];
    //   this.populateForm()
    //   this.populateLocation();
    // }, err => {
    //   if (err.status == 404)
    //     this.router.navigate(['/house']);
    // });
    this.houseService.getLocations().subscribe(dt => {
      this.cities = dt;
      this.populateLocation();
      this.houseService.getHouse(this.house.id).subscribe( dt => {
        this.house = dt;
        this.populateForm()
      })
    })
    
  }
  populateForm() {
   
    this.houseForm.patchValue(
      this.house
    )
    this.houseForm.controls.name.patchValue(this.house.contact.name);
    this.houseForm.controls.email.patchValue(this.house.contact.email);
    this.houseForm.controls.phone.patchValue(this.house.contact.phone);
    this.houseForm.controls.city.patchValue(this.house.city.id);
    this.populateLocation();
    this.houseForm.controls.location.patchValue(this.house.location.id);
    
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
      this.house.isOwner = this.houseForm.controls.isOwner.value == 'true'? true: false; 
      this.house.contact  =  {
        name: this.houseForm.controls.name.value,
        phone: this.houseForm.controls.phone.value,
        email: this.houseForm.controls.email.value
      }       
    }

    this.houseService.update(this.house).subscribe(
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
