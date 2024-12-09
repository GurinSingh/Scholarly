import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, Validators} from '@angular/forms';
import { ArticleService } from '../../../services/dbservice/article/article.service';
import { ArticleImageUploadService } from '../../../services/articleImageUploadService/article-image-upload.service';

@Component({
  selector: 'app-write-article',
  templateUrl: './write-article.component.html',
  styleUrl: './write-article.component.css'
})
export class WriteArticleComponent implements OnInit {
  
  uploadedData: any[] = [];

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
