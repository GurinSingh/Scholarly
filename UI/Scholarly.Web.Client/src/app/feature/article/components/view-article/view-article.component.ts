import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { article } from '../../../../core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { ArticleService } from '../../../../core';


@Component({
  selector: 'view-article',
  templateUrl: './view-article.component.html',
  styleUrl: './view-article.component.css',
  //encapsulation: ViewEncapsulation.ShadowDom
})

export class ViewArticleComponent implements OnInit {
  @Input() article: article = <any>{};

  constructor(private route: ActivatedRoute
    , private location:Location, private articleService: ArticleService) { }

  ngOnInit(): void {
    let selector: string = this._getSelector();
    if(selector == null)
      return;

    this.articleService.getBySelector(encodeURIComponent(selector)).subscribe((value: article)=>{
      this.article = {
        id: value.id,
        title: value.title,
        introduction: value.introduction,
        description: value.description,
        images: []
      };
    });
  }
  
  private _getSelector(): string{
    let selector!: string;
    this.route.paramMap.subscribe(params =>{
      selector = <string>params.get('selector');
    });

    return selector;
  }
}
