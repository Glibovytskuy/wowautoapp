import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { FooterComponent } from '../components/footer/footer.component';
import { AuthService } from '@app/services/auth.service';
import { HttpClientService } from '@app/services/general-services/http-client.service';
import { MobileMenuModalComponent } from './mobile-menu-modal/mobile-menu-modal.component';

@NgModule({
  imports: [
    FormsModule,
    ReactiveFormsModule
  ],
  declarations:[
    FooterComponent,
    MobileMenuModalComponent
  ],
  providers: [
    AuthService,
    HttpClientService
  ],
  exports:[
    FooterComponent, 
    FormsModule, 
    ReactiveFormsModule,
    MobileMenuModalComponent
  ]
})

export class SharedModule {}