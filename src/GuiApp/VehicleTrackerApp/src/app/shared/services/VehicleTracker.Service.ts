import { Customer } from '../models/Customer.Model';
import { Vehicle } from '../models/Vehicle.Model';
import { VehicleStatus } from '../models/VehicleStatus.Model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class VehicleTrackerService {

  vehicleList: Vehicle[];

  readonly baseApiGatewayURL = 'https://localhost:44300/';

  readonly baseVehicleDataURL = 'https://localhost:44302/api/v1';

  readonly vehiclesUrl = this.baseVehicleDataURL + "/Vehicle";
  readonly customersUrl = this.baseVehicleDataURL + "/Customer";


  constructor(private http: HttpClient) { }

  getAllVehicles() {
    return this.http.get<any>(this.vehiclesUrl);

    // this.http.get(this.vehiclesUrl)
    // .toPromise()
    // .then(res => {
    //   

    //   this.vehicleList = res as Vehicle[]
    // });
  }


  getAllCustomers() {
    return this.http.get<any>(this.customersUrl);
  }

}
