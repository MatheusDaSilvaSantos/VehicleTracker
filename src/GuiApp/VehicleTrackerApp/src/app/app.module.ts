
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { VehicleTrackeComponent } from './components/vehicle-tracker/vehicle-tracker.component';
import { VehicleTrackerListComponent } from './components/vehicle-tracker/vehicle-tracker-list/vehicle-tracker-list.component';

//import { AppRoutingModule } from './app-routing.module';  

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { VehicleTrackerService } from './shared/services/VehicleTracker.Service';
import { SignalRService } from './shared/services/signal-r.service';


@NgModule({
  declarations: [
    AppComponent,
    VehicleTrackeComponent,
    VehicleTrackerListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    //AppRoutingModule,  
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    VehicleTrackerService,
    SignalRService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }