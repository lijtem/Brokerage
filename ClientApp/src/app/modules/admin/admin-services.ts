import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { KeyValuePairModel } from '../Vehicles/models/vehicle-model';

@Injectable({
  providedIn: 'root'
})
export class AdminServices {

  private readonly cityEndpoint = '/api/city';

  constructor(private http: HttpClient) { }

  getCities() {
    return this.http.get<KeyValuePairModel[]>('/api/city')
      .pipe(res => res);
  }
  createCity(city: any){
    const _city = {
      'name': city.name
    }
    return this.http.post('/api/city', _city)
      .pipe(res => res);
  }
  editCity(city: any){
    const _city = {
      'name': city.name,
      'id': city.id
    }
    return this.http.put('/api/city/' + _city.id, _city)
      .pipe(res => res);
  }

  deleteCity(city: any){
    return this.http.delete('/api/city/' + city.id)
      .pipe(res => res);
  }

  createLocation(location: any){
    const _location = {
      'name': location.name,
      'CityId': location.cityId
    }
    return this.http.post('/api/location', _location)
      .pipe(res => res);
  }

  editLocation(location: any){
    const _location = {
      'name': location.name,
      'CityId': location.cityId
    }
    return this.http.put('/api/location/'+ location.id, _location)
      .pipe(res => res);
  }

  deleteLocation(location: any){
    return this.http.delete('/api/location/'+ location.id)
      .pipe(res => res);
  }
}
