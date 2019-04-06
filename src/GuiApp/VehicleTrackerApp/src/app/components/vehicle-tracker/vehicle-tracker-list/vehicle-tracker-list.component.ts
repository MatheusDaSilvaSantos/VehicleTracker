import { Vehicle } from '../../../shared/models/Vehicle.Model';
import { Customer } from '../../../shared/models/Customer.Model';
import { VehicleStatus } from '../../../shared/models/VehicleStatus.Model';
import { VehicleTrackerService } from '../../../shared/services/VehicleTracker.Service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SignalRService } from '../../../shared/services/signal-r.service';



@Component({
    selector: 'app-vehicle-tracker-list',
    templateUrl: './vehicle-tracker-list.component.html',
    styleUrls: ['./vehicle-tracker-list.component.css']
})
export class VehicleTrackerListComponent implements OnInit {

    public searchText: string;
    customers: Customer[];
    vehicles: Vehicle[];
    vehicleStatusList: VehicleStatus[];

    constructor(
        private vehicleTrackerService: VehicleTrackerService,
        private signalRService: SignalRService
    ) {

    }

    ngOnInit() {
        this.getVehicles();

        this.subscribeToEvents();
        this.signalRService.connectionEstablished.subscribe(() => {
            // pot soem logic here 
        });

    }


    getCustomerName(customerId) {
        return this.customers.find(c => c.id == customerId).name;
    }

    private getVehicles(): void {
        this.vehicleTrackerService
            .getAllVehicles()
            .subscribe((res: any) => {
                //debugger;
                console.log(res);
                this.vehicles = res.data;
                this.getCustomers();
                console.log(this.vehicles);
            },
                err => {
                    debugger;
                    console.log(err);
                });

    }


    private getCustomers(): void {
        this.vehicleTrackerService
            .getAllCustomers()
            .subscribe((res: any) => {
                //debugger;
                console.log(res);
                this.customers = res.data;
                this.updateVehiclesInitData();
            },
                err => {
                    debugger;
                    console.log(err);
                });

    }

    private updateVehiclesInitData(): void {
        var that = this;
        this.vehicles.forEach(function (vehicle) {
            vehicle.customerName = that.getCustomerName(vehicle.customerId);
            vehicle.statusString = vehicle.status ? 'Connected' : 'Disconnected';
        });
    }

    private subscribeToEvents(): void {
        this.signalRService.statusReceived.subscribe((data: VehicleStatus[]) => {
            debugger;
            console.log(data);
            this.updateVehiclesStatus(data);
        });
    }

    private updateVehiclesStatus(vehicleStatusData: VehicleStatus[]): void {
        var that = this;
        vehicleStatusData.forEach(function (statusItem) {
            debugger;
            console.log(statusItem);
            let vehicleIndex = that.vehicles.findIndex(v => v.vehicleId == statusItem.vehicleId);
            if (that.vehicles[vehicleIndex] != null) {
                that.vehicles[vehicleIndex].status = statusItem.status
            }
            debugger;
            console.log(that.vehicles[vehicleIndex]);
        });

        // for (let statusItem of vehicleStatusData) {
        //     debugger;
        //     console.log(statusItem);
        //     let vehicleIndex = this.vehicles.findIndex(v => v.vehicleId == statusItem.vehicleId);
        //     if (this.vehicles[vehicleIndex] != null) {
        //         this.vehicles[vehicleIndex].status = statusItem.status
        //     }
        //     debugger;
        //     console.log(this.vehicles[vehicleIndex]);
        // }
    }
}
