import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { WriteArticleComponent } from './components/write-article/write-article.component';
import { PopoverModule } from 'ngx-bootstrap/popover'
import { ViewArticleComponent } from './components/view-article/view-article.component';
import { FeatureViewarticleModule } from './feature.viewarticle.module';

@NgModule({
  declarations: [
    WriteArticleComponent
  ],
  imports: [
    CommonModule, ReactiveFormsModule, PopoverModule, FeatureViewarticleModule
],
  exports:[
    WriteArticleComponent
  ]
})
export class FeatureWritearticleModule { }
