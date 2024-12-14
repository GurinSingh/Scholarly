import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { ImageUploaderComponent } from './components/image-uploader/image-uploader.component';
import { ArticleContentComponent } from './components/article-content/article-content/article-content.component';



@NgModule({
  declarations: [
    ImageUploaderComponent,
    ArticleContentComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports:[
    ImageUploaderComponent
  ]
})
export class SharedModule { }
