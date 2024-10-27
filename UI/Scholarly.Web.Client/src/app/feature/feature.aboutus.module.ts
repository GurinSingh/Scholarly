import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    AboutUsComponent
  ],
  imports: [
    CommonModule,FontAwesomeModule,RouterModule
  ],
  exports:[AboutUsComponent]
})
export class FeatureAboutusModule { }
