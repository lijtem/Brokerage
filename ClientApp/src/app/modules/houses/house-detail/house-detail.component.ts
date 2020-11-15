import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HouseService } from '../house.service';

@Component({
  selector: 'app-house-detail',
  templateUrl: './house-detail.component.html',
  styleUrls: ['./house-detail.component.css']
})
export class HouseDetailComponent implements OnInit {

  house: any;
  houseId: number;
  constructor(private houseServce: HouseService, private route: ActivatedRoute,
    private router: Router,) {
    route.params.subscribe(p => {
      this.houseId = +p['id'];
    });
  }

  ngOnInit() {
    this.getHouseDetail();
  }
  getHouseDetail() {
    if (this.houseId) {
      this.houseServce.getHouse(this.houseId).subscribe(
        dt => {
          this.house = dt
        }, err => {
          if (err.status == 404)
            this.router.navigate(['/house']);
        }
      )

    }
  }

}
