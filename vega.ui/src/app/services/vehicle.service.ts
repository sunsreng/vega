import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SaveVehicle } from '../models/savevehicle';
import { Vehicle } from '../models/vehicle';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class VehicleService {

  constructor(private http: HttpClient) { }

  getMakes() {
    return this.http.get('http://localhost:5000/api/makes');
  }

  getFeatures() {
    return this.http.get('http://localhost:5000/api/features');
  }

  create(vehicle) {
    return this.http.post('http://localhost:5000/api/vehicles', vehicle);
  }

  getVehicle(id): Observable<Vehicle> {
    return this.http.get<Vehicle>('http://localhost:5000/api/vehicles/' + id);
  }

  getVehicles(): Observable<Vehicle> {
    return this.http.get<Vehicle>('http://localhost:5000/api/vehicles');
  }

  update(vehicle: SaveVehicle) {
    return this.http.put('http://localhost:5000/api/vehicles/' + vehicle.id, vehicle);
  }

  delete(id) {
    return this.http.delete('http://localhost:5000/api/vehicles/' + id);
  }
}
