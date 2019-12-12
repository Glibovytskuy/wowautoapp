import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../shared/shared.module';
import { RegistrationRoutingModule } from './registration-routing.module';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { RecoverPasswordComponent } from './recover-password/recover-password.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { CreditApplicationComponent } from './credit-application/credit-application.component';
import { ChooseApplicationComponent } from './choose-application/choose-application.component';

@NgModule({
  imports: [
    CommonModule,
    RegistrationRoutingModule,
    SharedModule
  ],
  declarations: [
    RegisterComponent, 
    LoginComponent, 
    RecoverPasswordComponent, 
    ChangePasswordComponent,
    ChooseApplicationComponent,
    CreditApplicationComponent
  ]
})
export class RegistrationModule { }
