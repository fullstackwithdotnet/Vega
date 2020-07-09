import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private http: HttpClient) { }

  GetAllVehicles(filter: any) {
    const querySting = 'api/vehicles?' + this.toQueryString(filter);
    return this.http.get(querySting);
  }

  private toQueryString(obj) {
    const parts = [];
    for (const property in obj) {
      if (obj.hasOwnProperty(property)) {
        const value = obj[property];
        if (value != null && value !== undefined) {
          parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
        }
      }
    }
    console.log(parts.join('&'));
    return parts.join('&');
  }


  public getMakes() {
    return this.http.get('api/makes');
  }
  public getFeatures() {
    return this.http.get('api/features');
  }

  Add(vehicle) {
    return this.http.post('api/vehicle', vehicle);
  }

  GetVehicle(vehicleId: any) {
    return this.http.get('api/vehicles/' + vehicleId);
  }

  delete(vehicleId: number) {
    return this.http.delete('api/vehicles/' + vehicleId);
  }


}
