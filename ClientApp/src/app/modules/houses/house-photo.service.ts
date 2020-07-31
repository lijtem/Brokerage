import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HousePhotoService {

  constructor(private http: HttpClient) { }

  upload(houseId,photo){
    var formData = new FormData();
    formData.append('file', photo);
    return this.http.post(`/api/houses/${houseId}/photos`, formData)
    .pipe(res => res);
  }
}
