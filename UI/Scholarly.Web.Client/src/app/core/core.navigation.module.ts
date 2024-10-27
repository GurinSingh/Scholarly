import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopNavigationComponent } from './components/top-navigation/top-navigation.component';
import { RouterLink } from '@angular/router';



@NgModule({
  declarations: [
    TopNavigationComponent
  ],
  imports: [
    CommonModule, RouterLink
  ],
  exports:[TopNavigationComponent]
})
export class CoreNavigationModule { }
