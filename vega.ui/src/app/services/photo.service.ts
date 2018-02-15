import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class PhotoService {
  constructor(private http: HttpClient) { }

  upload(vehicleId, photo) {
    const formData = new FormData();
    formData.append('file', photo);
    return this.http.post(`http://192.168.1.112/vega/api/vehicles/${vehicleId}/photos`, formData);
  }

  getPhotos(vehicleId) {
    return this.http.get(`http://192.168.1.112/vega/api/vehicles/${vehicleId}/photos`);
  }
}
