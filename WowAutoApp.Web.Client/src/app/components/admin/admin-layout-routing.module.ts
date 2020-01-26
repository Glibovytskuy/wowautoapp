import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminLayoutComponent } from './admin-component/admin-layout/admin-layout.component';
import { VehicleManagmentComponent } from './vehicle/vehicle-managment/vehicle-managment/vehicle-managment.component';
import { AddVehicleComponent } from './vehicle/add-vehicle/add-vehicle/add-vehicle.component';
import { EditVehicleComponent } from './vehicle/edit-vehicle/edit-vehicle/edit-vehicle.component';

const routes: Routes = [
  {
    path: '',
    component: AdminLayoutComponent,
    children: [
        {
          path: 'vehicles',
          loadChildren: './vehicle/vehicle-managment.module#VehicleManagmentModule',
          data: {}
        }
    ]
  },
  {path: '**', redirectTo: 'not-found'}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminLayoutRoutingModule { }