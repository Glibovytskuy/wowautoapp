import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfileRoutingModule } from './profile-routing.module';
import { MainProfileComponent } from './main-profile/main-profile.component';
import { SharedModule } from '../../shared/shared.module';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';

@NgModule({
  imports: [
    CommonModule,
    ProfileRoutingModule,
    SharedModule
  ],
  declarations: [
    MainProfileComponent,
    ConfirmEmailComponent
  ]
})
export class ProfileModule { }
