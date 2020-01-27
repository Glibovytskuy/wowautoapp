import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PrivacyComponent } from './components/about/privacy/privacy.component';
import { NotFoundComponent } from './static/not-found/not-found/not-found.component';

const routes: Routes = [
  { 
    path: '', 
    component: HomeComponent 
  },

  {
    path: 'about/privacy',
    component: PrivacyComponent
  },

  {
    path: 'admin',
    loadChildren: './components/admin/admin-layout.module#AdminLayoutModule'
    // canActivate: [RoleGuard],
    // data: {roles: [Role.SystemAdmin]}
  },
  {
      path: 'not-found',
      data: {},
      component: NotFoundComponent,
      //canActivate: [AuthGuard]
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