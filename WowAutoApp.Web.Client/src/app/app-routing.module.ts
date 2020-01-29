import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PrivacyComponent } from './components/about/privacy/privacy.component';
import { NotFoundComponent } from './static/not-found/not-found/not-found.component';
import { Role } from './core/enums/Role';
import { RoleGuard } from './services/guards/role.guards';
import { NonAuthGuard } from './services/guards/non-auth.guard';
import { AuthGuard } from './services/guards/auth.guard';

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
    loadChildren: './components/admin/admin-layout.module#AdminLayoutModule',
    canActivate: [RoleGuard],
    data: {roles: [Role.SystemAdmin]}
  },
  {
      path: 'not-found',
      data: {},
      component: NotFoundComponent
  },
  { 
    path: '',
    loadChildren: './components/registration/registration.module#RegistrationModule',
    canActivate: [NonAuthGuard] 
  },

  { 
    path: '',
    loadChildren: './components/profile/profile.module#ProfileModule',
    canActivate: [AuthGuard]
  },

  {path: '**', redirectTo: 'not-found'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }