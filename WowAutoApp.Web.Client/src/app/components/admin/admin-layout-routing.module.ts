import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminLayoutComponent } from './admin-component/admin-layout/admin-layout.component';

const routes: Routes = [
  {
    path: '',
    component: AdminLayoutComponent,
    data:{},
    children: [
      {
        path: 'vehicles',
        loadChildren: './vehicle/vehicle-managment.module#VehicleManagmentModule',
        data: {}
      },
      {
        path: '',
        redirectTo: '/admin/vehicles'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminLayoutRoutingModule { }