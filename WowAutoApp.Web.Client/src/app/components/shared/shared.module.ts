import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { FooterComponent } from '../footer/footer.component';

@NgModule({
  imports: [
    FormsModule,
    ReactiveFormsModule
  ],
  declarations:[
    FooterComponent
  ],
  exports:[
    FooterComponent, 
    FormsModule, 
    ReactiveFormsModule
  ]
})

export class SharedModule {}