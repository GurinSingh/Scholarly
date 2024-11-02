import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WriteContentComponent } from './write-content/write-content.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    WriteContentComponent
  ],
  imports: [
    CommonModule, ReactiveFormsModule
  ],
  exports:[
    WriteContentComponent
  ]
})
export class FeatureWritecontentModule { }
