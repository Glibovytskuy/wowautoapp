import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CreditApplicationComponent } from './components/credit-application/credit-application.component';
import { ChooseApplicationComponent } from './components/choose-application/choose-application.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: '', loadChildren: './components/registration/registration.module#RegistrationModule' },
  { path: '', loadChildren: './components/profile/profile.module#ProfileModule' },
  { path: 'credit-application', component: CreditApplicationComponent },
  { path: 'choose-application', component: ChooseApplicationComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }