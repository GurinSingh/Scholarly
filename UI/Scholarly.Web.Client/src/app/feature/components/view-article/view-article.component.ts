import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import { article } from '../../models/article/feature.article.model';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { DomSanitizer } from '@angular/platform-browser';
import { ArticleService } from '../../../services/dbservice/article/article.service';
import { ScholarlyHTMLMappingService } from '../../../services/scholarlyHtmlMapping/scholarly-htmlmapping.service';
import { PopoverModule } from 'ngx-bootstrap/popover';


@Component({
  selector: 'app-view-article',
  templateUrl: './view-article.component.html',
  styleUrl: './view-article.component.css',
})

export class ViewArticleComponent implements OnInit, AfterViewInit {
  @Input() article: article = <any>{};

  constructor(private route: ActivatedRoute
    , private location:Location, private articleService: ArticleService, private pop: PopoverModule) { }

  ngOnInit(): void {
    if(this.route.snapshot.routeConfig?.path != 'write/article'){
      let article = this.articleService.getBySelector(this._getEncodeSelector());
      article.subscribe(value=>{
        this.article = {
          id: value.id,
          title: value.title,
          introduction: value.introduction,
          description: value.description,
          images: []
        };
      });
    }
  }
  ngAfterViewInit(): void {
  }
  
  private _getEncodeSelector(selector?: string): string{
    if(selector == null){
      let path: string = this.location.path(true);

      let routePath:string = '';
        this.route.url.subscribe(segment=> {
         routePath = '/'+segment.filter((s,i)=> i != (segment.length - 1)).map(x=> x.path).join('/')+'/';
        })
      
        return encodeURIComponent(path.replace(routePath, ''));
    }
    
    return encodeURIComponent(selector);
  }
}
