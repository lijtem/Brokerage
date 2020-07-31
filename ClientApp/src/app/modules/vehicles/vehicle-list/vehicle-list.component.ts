import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { VehicleService } from '../vehicle.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements  OnInit {
  queryResult: any = {};
  dataSource: MatTableDataSource<any>;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  private readonly PAGE_SIZE = 8;
 
  makes: any;
  models: any[];
  vehicle: any = {
    modelId: 0,
    IsOwner: false,
    code: '',
  };
  query: any = {
    pageSize: this.PAGE_SIZE
  };

  
  displayedColumns: string[] = [ 'vehicle', 'year', 'contact', 'phone',  'code', 'action'];
  vehicles: Object;
  constructor(private vehicleService: VehicleService,private router: Router,) { 
    this.dataSource = new MatTableDataSource(this.queryResult.items);
  }

  ngOnInit() {
    this.vehicleService.getMakes()
    .subscribe(makes => this.makes = makes);
    this.populateVehicles()
    this.dataSource.sort = this.sort;
  }

  
  private populateVehicles() {
    this.vehicleService.getVehicles(this.query)
      .subscribe(result =>
        { 
          this.queryResult = result;
          this.dataSource= this.queryResult.items
    });
  }

  onFilterChange() {

    this.query.page = 1;
    this.populateVehicles();
  }

  applyFilter(){
    this.query.page = 1;
    this.populateVehicles();
  }
  resetFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populateVehicles();
  }

  sortBy(columnName) {
    if (this.query.sortBy === columnName) {
      this.query.isSortAscending = !this.query.isSortAscending;
    } else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }
    this.populateVehicles();
  }

  onPageChange(page) {
    this.query.page = page;
    this.populateVehicles();
  }

  onOwnerToggle($event){
    if ($event.target.checked)
      this.query.isOwner = true

  }

  onMakeChange() {
    this.populateModels();
    delete this.vehicle.modelId;
  }

  private populateModels() {
    var selectedMake = this.makes.find(m => m.id == this.query.makeId);
    this.models = selectedMake ? selectedMake.models : [];
  }

  delete(element) {
    
    if (confirm("Are you sure?")) {
      this.vehicleService.delete(element)
        .subscribe(x => {
          this.populateVehicles();
        });
    }
  }
  edit(element){
    this.router.navigate(['/vehicle/edit/'+element]);
  }
}
