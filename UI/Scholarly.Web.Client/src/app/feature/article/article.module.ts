import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewArticleComponent } from './components/view-article/view-article.component';
import { WriteArticleComponent } from './components/write-article/write-article.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MapToHtmlDirective } from '../../shared';
import { PageNavigationRendererDirective } from '../../shared';
import { ArticleRoutingModule } from './article-routing.module';
import { ArticleContentComponent } from '../../shared/components/article-content/article-content/article-content.component';



@NgModule({
  declarations: [ViewArticleComponent,
    WriteArticleComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MapToHtmlDirective,
    PageNavigationRendererDirective,
    ArticleRoutingModule
  ],
  exports:[
    ViewArticleComponent,
    WriteArticleComponent
  ]
})
export class ArticleModule { }
