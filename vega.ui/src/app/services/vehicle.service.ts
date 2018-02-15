import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { SaveVehicle } from '../models/savevehicle';
import { Vehicle } from '../models/vehicle';

@Injectable()
export class VehicleService {
  private readonly apiEndpoint = 'http://192.168.1.112/vega/api/';

  constructor(private http: HttpClient) { }

  getMakes() {
    return this.http.get(this.apiEndpoint + 'makes');
  }

  getFeatures() {
    return this.http.get(this.apiEndpoint + 'features');
  }

  create(vehicle) {
    return this.http.post(this.apiEndpoint + 'vehicles', vehicle);
  }

  getVehicle(id: number): Observable<Vehicle> {
    return this.http.get<Vehicle>(this.apiEndpoint + 'vehicles/' + id);
  }

  getVehicles(filter) {
    return this.http.get(this.apiEndpoint + 'vehicles?' + this.toQueryString(filter));
  }

  toQueryString(obj) {
    const parts = [];
    // tslint:disable-next-line:forin
    for (const property in obj) {
      const value = obj[property];
      if (value !== null && value !== undefined) {
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
      }
    }

    return parts.join('&');
  }

  update(vehicle: SaveVehicle) {
    return this.http.put(this.apiEndpoint + 'vehicles/' + vehicle.id, vehicle);
  }

  delete(id) {
    return this.http.delete(this.apiEndpoint + 'vehicles/' + id);
  }
}
