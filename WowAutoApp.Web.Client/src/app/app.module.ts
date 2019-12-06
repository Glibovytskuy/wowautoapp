import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { SharedModule } from './components/shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './components/home/home.component';

import { CreditApplicationComponent } from './components/credit-application/credit-application.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CreditApplicationComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserModule,
    SharedModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
