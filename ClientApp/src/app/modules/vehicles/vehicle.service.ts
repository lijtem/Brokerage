import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { KeyValuePairModel, SaveVehicleModel } from './models/vehicle-model';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  private readonly vehiclesEndpoint = '/api/vehicles';

  constructor(private http: HttpClient) { }

  getFeatures() {
    return this.http.get<any>('/api/features')
      .pipe(res => res);
  }
//   getAll(): Observable<KeyValuePairM[]> {
//     return this.http.get<Client[]>(`${this.url}/clients`).map(res=>res.json());
// }
  getMakes() {
    return this.http.get<KeyValuePairModel[]>('/api/makes')
      .pipe(res => res);
  }
  getVehicles(filter) {
    return this.http.get(this.vehiclesEndpoint + '?' + this.toQueryString(filter))
      .pipe(res => res);
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
  create(vehicle) {
    vehicle.modelId = parseInt(vehicle.modelId)
    var x = {
      "modelId": parseInt(vehicle.modelId),
      "IsOwner": vehicle.IsOwner,
      "features": vehicle.features,
      "contact": vehicle.contact,
      "yearMade":vehicle.yearMade,
      "color":vehicle.color,
      "transmission":vehicle.transmission,
      "engineType":vehicle.engineType,
      "engineSize":vehicle.engineSize,
      "price":vehicle.price,
      "code":vehicle.code,

    }
   // var x = { "isRegistered": true, "features": [7, 16], "contact": { "name": "Yonathan", "email": "abc@gmail.com", "phone": "0911232323" },   "modelId": 10 }
    return this.http.post(this.vehiclesEndpoint, x
    )
      .pipe(res => res);
  }

  getVehicle(id) {
    return this.http.get('/api/vehicles/' + id)
      .pipe(res => res);
  }

  update(vehicle: SaveVehicleModel) {
    
    return this.http.put('/api/vehicles/' + vehicle.id, vehicle)
      .pipe(res => res);
  }

  delete(id) {
    return this.http.delete('/api/vehicles/' + id)
      .pipe(res => res);
  }

  
  createMake(make: any){
    const _make = {
      'name': make.name
    }
    return this.http.post('/api/makes/', _make)
      .pipe(res => res);
  }
  editMake(make: any){
    const _make = {
      'name': make.name,
      'id': make.id
    }
    return this.http.put('/api/makes/' + _make.id, _make)
      .pipe(res => res);
  }

  deleteMake(make: any){
    return this.http.delete('/api/makes/' + make.id)
      .pipe(res => res);
  }

  createModel(model: any){
    const _model = {
      'name': model.name,
      'makeId': model.makeId
    }
    return this.http.post('/api/models/', _model)
      .pipe(res => res);
  }
  editModel(model: any){
    const _model = {
      'name': model.name,
      'makeId': model.makeId
    }
    return this.http.put('/api/models/'+ model.id, _model)
      .pipe(res => res);
  }
  deleteModel(model: any){
    return this.http.delete('/api/models/'+ model.id)
      .pipe(res => res);
  }
  
}
