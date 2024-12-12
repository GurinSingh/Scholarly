import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationComponent } from '../../pages/registration/registration.component';
import { UserRoutingModule } from './user-routing.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    UserRoutingModule
  ],
  exports: []
})
export class UserModule { }
