import { Component, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, Validators} from '@angular/forms';
import { ArticleService } from '../../../../core';
import { ArticleImageUploadService } from '../../../../core';
import { ImageUploaderComponent } from '../../../../shared';

@Component({
  selector: 'write-article',
  templateUrl: './write-article.component.html',
  styleUrl: './write-article.component.css'
})
export class WriteArticleComponent implements OnInit {
  uploadedData!: any[];

  constructor(private formBuilder: FormBuilder, private articleService: ArticleService
    ,private _imageUploadService: ArticleImageUploadService) { }

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

  openUploader(): void{
    this._imageUploadService.openUploader();
  }
}
