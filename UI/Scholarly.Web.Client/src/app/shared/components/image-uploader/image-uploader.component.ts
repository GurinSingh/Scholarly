import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { ArticleImageUploadService } from '../../../core';

type uploadedImage = {
  selector: string;
  caption: string;
  image: File
}
@Component({
  selector: 'image-uploader',
  templateUrl: './image-uploader.component.html',
  styleUrl: './image-uploader.component.css'
})
export class ImageUploaderComponent {
  uploadedData = new EventEmitter<any>();
  selectedFile: File | null = null;
  uploadedImage: uploadedImage = <any>{};

  constructor(private _formBuilder: FormBuilder, private _imageuploader: ArticleImageUploadService) {
  }

  form = this._formBuilder.group({
    selector: [''],
    caption: [''],
    image: [null] 
  });

  onSubmit(){
    let formData = {
      selector: this.form.value.selector,
      caption: this.form.value.caption,
      url: URL.createObjectURL(<any>this.selectedFile),
      image: this.selectedFile
    };

    this.uploadedData.emit(formData);
    
    this._imageuploader.closeUploader();
    this.selectedFile = null;
  }
  onFileSelected(args: any){
    const input = args.target as HTMLInputElement;

    if(input.files)
      this.selectedFile = Array.from(input.files)[0];
    
  }

  
}
