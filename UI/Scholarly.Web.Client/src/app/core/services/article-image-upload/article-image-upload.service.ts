import { EventEmitter, Injectable, Type } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subject } from 'rxjs';
import { ImageUploaderComponent } from '../../../shared/components/image-uploader/image-uploader.component';
import { Title } from '@angular/platform-browser';

type imageData={selector:string, url: string, caption: string, image: File };
@Injectable({
  providedIn: 'root'
})
export class ArticleImageUploadService {
  private modalRef?: BsModalRef;
  uploadedData$: EventEmitter<imageData> = new EventEmitter<imageData>();
  private _images:imageData[] = <any>[];

  constructor(private _modalService: BsModalService) {
   }

  openUploader(){
    this.modalRef = this._modalService.show(ImageUploaderComponent, {
      backdrop: 'static',
      class: 'modal-lg'
    });

    this.modalRef.content?.uploadedData.subscribe((data:imageData) => {
      if(this._images.some(img=> img.selector == data.selector))
        return;

      this._images.push(data)
    });
  }

  closeUploader(){
    this._modalService.hide(this.modalRef?.id);
  }

  getAllImages(): imageData[]{
    return this._images;
  }
  getImage(selector: string): imageData{
    return this._images.filter(img => img.selector == selector)[0] || {};
  }
}
