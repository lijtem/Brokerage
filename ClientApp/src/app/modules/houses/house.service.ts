import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SaveHouseModel } from './models/house-model';

@Injectable({
  providedIn: 'root'
})
export class HouseService {
  
  private readonly houseEndpoint = '/api/houses';

  constructor(private http: HttpClient) { }

  getLocations(){
    return this.http.get<any[]>('api/locations').pipe(res => res);
  }

  create(house){
    return this.http.post<any>(this.houseEndpoint, house).pipe(
      res => res
    );
  }

  getHouses(filter){
    return this.http.get(this.houseEndpoint + '?' + this.toQueryString(filter)).pipe(res => res);
  }

  getHouse(id){
    return this.http.get<SaveHouseModel>('/api/houses/' + id).pipe(res => res);
  }

  
  
  toQueryString(obj) {
    var parts = [];
    for (var property in obj) {
      var value = obj[property];
      if (value != null && value != undefined)
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
    }

    return parts.join('&');
  }

  update(house: SaveHouseModel) {    
    return this.http.put('/api/houses/' + house.id, house)
      .pipe(res => res);
  }

  delete(id){
    return this.http.delete('/api/houses/' + id)
      .pipe(res => res);
  }
}
