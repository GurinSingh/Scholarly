import { Component, EventEmitter, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, Validators} from '@angular/forms';
import { ArticleService } from '../../../../core';
import { ArticleImageUploadService } from '../../../../core';
import { ImageUploaderComponent } from '../../../../shared';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ArticleContentComponent } from '../../../../shared/components/article-content/article-content/article-content.component';

@Component({
  selector: 'write-article',
  templateUrl: './write-article.component.html',
  styleUrl: './write-article.component.css'
})
export class WriteArticleComponent implements OnInit {
  modalRef?: BsModalRef;
  constructor(private formBuilder: FormBuilder, private articleService: ArticleService
    , private _content: BsModalService) { }

  ngOnInit(): void {
  }

  writeArticleForm = <any>this.formBuilder.group({
    id:0,
    title: ['', Validators.required],
    introduction: ['', Validators.required],
    description: ['', Validators.required],
    images: []
  });

  
  saveArticle() {
    this.articleService.insert(<any>this.writeArticleForm.value).subscribe();
  }

  openContent(): void{
    this.modalRef = this._content.show(ArticleContentComponent,{
      backdrop: 'static',
      class: 'modal-xl'
    });


  }
}
