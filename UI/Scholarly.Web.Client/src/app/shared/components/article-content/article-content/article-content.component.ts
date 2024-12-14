import { AfterViewInit, Component } from '@angular/core';
import { ArticleImageUploadService } from '../../../../core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-article-content',
  templateUrl: './article-content.component.html',
  styleUrl: './article-content.component.css'
})
export class ArticleContentComponent implements AfterViewInit {
  images:{selector: string, url: string, image: File, caption: string}[] = <any>[];
  constructor(private _imageUploadService: ArticleImageUploadService, public modalRef: BsModalRef) {
  }

  ngAfterViewInit(): void {
    this.images = this._imageUploadService.getAllImages(); 
  }

  openUploader(){
    this._imageUploadService.openUploader();
  }
  closeModal(){
    this.modalRef.hide();
  }
}
