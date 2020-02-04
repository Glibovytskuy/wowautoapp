import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { SharedModule } from './shared/shared.module';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './components/home/home.component';
import { CoreModule } from './core/core.module';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PrivacyComponent } from './components/about/privacy/privacy.component';
import { NotFoundComponent } from './static/not-found/not-found/not-found.component';
import { AboutUsComponent } from './components/about/about-us/about-us.component';
import { AboutWowautoComponent } from './components/about/about-wowauto/about-wowauto.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PrivacyComponent,
    NotFoundComponent,
    AboutUsComponent,
    AboutWowautoComponent
  ],
  imports: [
    CoreModule,
    CommonModule,
    BrowserModule,
    SharedModule,
    AppRoutingModule,
    ModalModule.forRoot(),
    ToastrModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
