import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class VehicleService {

  constructor(private http: HttpClient) { }

  getMakes() {
    return this.http.get('http://localhost:5000/api/makes');
  }

  getFeatures() {
    return this.http.get('http://localhost:5000/api/features');
  }
}
