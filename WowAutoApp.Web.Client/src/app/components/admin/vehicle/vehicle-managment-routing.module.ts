import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VehicleManagmentComponent } from './vehicle-managment/vehicle-managment/vehicle-managment.component';
import { AddVehicleComponent } from './add-vehicle/add-vehicle/add-vehicle.component';
import { EditVehicleComponent } from './edit-vehicle/edit-vehicle/edit-vehicle.component';

const routes: Routes = [
  {
    path: '',
    component: VehicleManagmentComponent,
    data: {}
  },
  {
    path: 'add',
    component: AddVehicleComponent,
    data: {}
  },
  {
    path: 'edit/:id',
    component: EditVehicleComponent,
    data: {}
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VehicleManagmentRoutingModule { }
