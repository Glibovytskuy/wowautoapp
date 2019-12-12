import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RecoverPasswordComponent } from './recover-password/recover-password.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { ChooseApplicationComponent } from './choose-application/choose-application.component';
import { CreditApplicationComponent } from './credit-application/credit-application.component';

const routes: Routes = [
  { path: 'recover-password', component: RecoverPasswordComponent },
  { path: 'change-password', component: ChangePasswordComponent },
  { path: 'login', component: LoginComponent },
  { path: 'applications', component: ChooseApplicationComponent },
  { path: 'applications/personal', component: CreditApplicationComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegistrationRoutingModule { }

