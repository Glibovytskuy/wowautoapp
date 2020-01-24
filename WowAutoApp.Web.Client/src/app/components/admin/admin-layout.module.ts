import { NgModule } from '@angular/core';

import { AdminLayoutRoutingModule } from './admin-layout-routing.module';
import { SharedModule } from '@app/shared/shared.module';
import { AdminLayoutComponent } from './admin-component/admin-layout/admin-layout.component';

@NgModule({
  imports: [
    SharedModule,
    AdminLayoutRoutingModule
  ],
  declarations: [
    AdminLayoutComponent
  ]
})

export class AdminLayoutModule { }