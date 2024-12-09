import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewArticleComponent } from './components/view-article/view-article.component';
import { ImageUploaderComponent } from "../shared/image-uploader/image-uploader.component";
import { MapToHtmlDirective } from '../directives/mapToHtml/map-to-html.directive';
import { PopoverDirective } from 'ngx-bootstrap/popover';
import { PageNavigationRendererDirective } from '../directives/pageNavigationRenderer/page-navigation-renderer.directive';



@NgModule({
  declarations: [
    ViewArticleComponent
  ],
  imports: [
    CommonModule,
    ImageUploaderComponent,
    MapToHtmlDirective,
    PopoverDirective,
    PageNavigationRendererDirective
],
  exports:[ViewArticleComponent,
    PageNavigationRendererDirective
  ]
})
export class FeatureViewarticleModule { }
