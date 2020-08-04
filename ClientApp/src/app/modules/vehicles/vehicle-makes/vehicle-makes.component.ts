import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { VehicleService } from '../vehicle.service';

@Component({
  selector: 'app-vehicle-makes',
  templateUrl: './vehicle-makes.component.html',
  styleUrls: ['./vehicle-makes.component.css']
})
export class VehicleMakesComponent implements OnInit {
  dataSource = new MatTableDataSource<any>();
  dataSourceModel = new MatTableDataSource<any>();
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild('modulePage', {static: true}) modulePage: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  displayedColumns: string[] = [ 'id', 'name',  'action'];
  displayedModelColumns: string[] = [ 'id', 'name',  'action'];

  private readonly PAGE_SIZE = 8;
 
  makes: any;
  models: any[];
  selectedMake: any = {};
  constructor(private vehicleService: VehicleService,) { }

  ngOnInit() {
    this.vehicleService.getMakes()
    .subscribe(makes =>{ this.makes = makes
      this.dataSource.data = makes;
    });
    this.dataSource.paginator = this.paginator;
    this.dataSourceModel.paginator = this.modulePage;
  }

  getDetail(index){
    debugger
    this.selectedMake = this.makes.find(m => m.id == index.id);
    this.models = this.selectedMake ? this.selectedMake.models : [];
    this.dataSourceModel.data = this.models;
  }

}
