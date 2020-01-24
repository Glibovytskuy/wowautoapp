import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { 
    path: '', 
    component: HomeComponent 
  },
  
  {
    path: 'admin',
    loadChildren: './components/admin/admin-layout.module#AdminLayoutModule'
    // canActivate: [RoleGuard],
    // data: {roles: [Role.SystemAdmin]}
  },

  { 
    path: '',
    loadChildren: './components/registration/registration.module#RegistrationModule' 
  },

  { 
    path: '',
    loadChildren: './components/profile/profile.module#ProfileModule' 
  },

  {path: '**', redirectTo: 'not-found'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }