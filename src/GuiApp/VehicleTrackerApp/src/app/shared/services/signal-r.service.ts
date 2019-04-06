import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Subject } from 'rxjs';
import { VehicleStatus } from '../models/VehicleStatus.Model';

const WAIT_UNTIL_ASPNETCORE_IS_READY_DELAY_IN_MS = 2000;

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  statusReceived = new Subject<VehicleStatus[]>();
  connectionEstablished = new Subject<Boolean>();

  //public vehicleStatusData: VehicleStatus[];

  private hubConnection: HubConnection

  constructor() {
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }


  private createConnection() {
    this.hubConnection = new HubConnectionBuilder()
      //.withUrl('https://localhost:44303/PingingHub')
      .withUrl('http://localhost:56645/PingingHub')// for http

      
      .build();
  }

  private startConnection() {
    setTimeout(() => {
      this.hubConnection
        .start()
        .then(() => {
          console.log('Hub connection started');
          this.connectionEstablished.next(true);
        })
        .catch(err => console.log('Error while starting connection: ' + err));
    }, WAIT_UNTIL_ASPNETCORE_IS_READY_DELAY_IN_MS);
  }



  public registerOnServerEvents = () => {
    this.hubConnection.on('vehiclesPinged', (data: any) => {
      console.log(data);
      this.statusReceived.next(data);
      console.log(this.statusReceived);
    });
  }

}
