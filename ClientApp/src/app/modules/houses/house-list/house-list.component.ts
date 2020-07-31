import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { HouseService } from '../house.service';
import { Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-house-list',
  templateUrl: './house-list.component.html',
  styleUrls: ['./house-list.component.css']
})
export class HouseListComponent implements OnInit {
  private readonly PAGE_SIZE = 8;
  cities: any;
  locations: any[];
  queryResult: any = {};
  dataSource: MatTableDataSource<any>;
  query: any = {
    pageSize: this.PAGE_SIZE
  };

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  displayedColumns: string[] = [ 'house', 'year', 'contact', 'phone',  'code', 'action'];

  houseForm = this.fb.group({
    city: [null],
    location: [null],
    code: [null],
    isOwner: [true],
  });
  constructor(private houseService: HouseService, 
    private router: Router,
    private fb: FormBuilder) {
    this.dataSource = new MatTableDataSource(this.queryResult.items);

  }


  ngOnInit() {
    this.populateProperty();
    this.dataSource.sort = this.sort;
    this.houseService.getLocations().subscribe(dt => {
      this.cities = dt;
    })
  }

  populateProperty() {
    this.houseService.getHouses(this.query).subscribe(result => {
      this.queryResult = result;
      this.dataSource = this.queryResult.items
    });
  }

  onCityChange() {
    this.populateLocation();
  }
  populateLocation() {
    var selectedLocation = this.cities.find(m => m.id == this.houseForm.controls.city.value);
    this.locations = selectedLocation ? selectedLocation.locations : [];
  }

  resetFilter(){
    this.houseForm.reset();
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populateProperty();
  }
  applyFilter(){
    
    if(this.houseForm.controls.city.value != null){
      this.query = {
        CityId: this.houseForm.controls.city.value,
      }
    }
    if(this.houseForm.controls.location.value != null){
      this.query = {
        LocationId: this.houseForm.controls.location.value,
      }
    }
    if(this.houseForm.controls.isOwner.value != null){
      this.query = {
        IsOwner: this.houseForm.controls.isOwner.value,
      }
    }
    if(this.houseForm.controls.code.value != null){
      this.query = {
        Code: this.houseForm.controls.code.value,
      }
    }
    this.query.page = 1;
    this.populateProperty();
  }

  delete(element) {
    
    if (confirm("Are you sure?")) {
      this.houseService.delete(element)
        .subscribe(x => {
          this.populateProperty();
        });
    }
  }
  edit(element){
    this.router.navigate(['/house/edit/'+element]);
  }

  onPageChange(page) {
    this.query.page = page;
    this.populateProperty();
  }

}
