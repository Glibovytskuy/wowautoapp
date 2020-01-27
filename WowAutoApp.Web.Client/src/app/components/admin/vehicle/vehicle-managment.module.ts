import { NgModule } from '@angular/core';

import { VehicleManagmentRoutingModule } from './vehicle-managment-routing.module';
import { VehicleManagmentComponent } from './vehicle-managment/vehicle-managment/vehicle-managment.component';
import { AddVehicleComponent } from './add-vehicle/add-vehicle/add-vehicle.component';
import { EditVehicleComponent } from './edit-vehicle/edit-vehicle/edit-vehicle.component';
import { SharedModule } from '@app/shared/shared.module';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    VehicleManagmentRoutingModule
  ],
  declarations: [
    VehicleManagmentComponent,
    AddVehicleComponent,
    EditVehicleComponent
  ],
  exports: [
    AddVehicleComponent,
    EditVehicleComponent
  ]
})
export class VehicleManagmentModule { }