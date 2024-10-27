import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRegistrationComponent } from './components/user-registration/user-registration.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    UserRegistrationComponent
  ],
  imports: [
    CommonModule, ReactiveFormsModule
  ],
  exports:[UserRegistrationComponent]
})
export class FeatureUserregistrationModule { }
