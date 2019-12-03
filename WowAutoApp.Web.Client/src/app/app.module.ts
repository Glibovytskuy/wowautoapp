import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './components/home/home.component';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CreditApplicationComponent } from './components/credit-application/credit-application.component';
import { FooterComponent } from './components/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CreditApplicationComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
