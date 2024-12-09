import { Injectable } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subject } from 'rxjs';
import { ImageUploaderComponent } from '../../shared/image-uploader/image-uploader.component';

@Injectable({
  providedIn: 'root'
})
export class ArticleImageUploadService {
  private modalRef?: BsModalRef;
  private imagesSubject = new Subject<any>();
  uploadedData$ = this.imagesSubject.asObservable();

  constructor(private _modalService: BsModalService) { }

  openUploader(){
    this.modalRef = this._modalService.show(ImageUploaderComponent, {
      backdrop: 'static',
      class: 'modal-lg'
    });

    this.modalRef.content?.uploadedData.subscribe((data:any) => {
      this.imagesSubject.next(data);
    });
  }

  closeUploader(){
    this._modalService.hide();
  }
}
