import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { HouseService } from '../house.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-house-list',
  templateUrl: './house-list.component.html',
  styleUrls: ['./house-list.component.css']
})
export class HouseListComponent implements OnInit {
  private readonly PAGE_SIZE = 10;
  queryResult: any = {};
  dataSource: MatTableDataSource<any>;
  query: any = {
    pageSize: this.PAGE_SIZE
  };

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  
  displayedColumns: string[] = ['id', 'house', 'year', 'contact', 'phone', 'isOwner', 'code', 'action'];

  constructor(private houseService: HouseService,private router: Router) { 
    this.dataSource = new MatTableDataSource(this.queryResult.items);

  }


  ngOnInit() {
    this.populateProperty();
    this.dataSource.sort = this.sort;
  }

  populateProperty(){
    this.houseService.getHouses(this.query).subscribe(result =>
      { 
        this.queryResult = result;
        this.dataSource= this.queryResult.items
  });
  }

}
