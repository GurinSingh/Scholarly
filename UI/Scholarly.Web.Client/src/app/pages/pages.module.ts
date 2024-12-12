import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorComponent } from './error/error.component';
import { RegistrationComponent } from './registration/registration.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [ErrorComponent,
    RegistrationComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [ErrorComponent,
    RegistrationComponent
  ]
})
export class PagesModule { }
