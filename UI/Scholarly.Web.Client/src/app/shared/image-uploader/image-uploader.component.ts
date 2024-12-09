import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { ArticleImageUploadService } from '../../services/articleImageUploadService/article-image-upload.service';

interface UploadedImage{
  url: string;
  name: string;
}
@Component({
  selector: 'image-uploader',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './image-uploader.component.html',
  styleUrl: './image-uploader.component.css'
})
export class ImageUploaderComponent {
  @Output() uploadedData = new EventEmitter<any>();
  selectedFile: File | null = null;
  uploadedImage: UploadedImage = <any>{};

  constructor(private _formBuilder: FormBuilder, private _imageuploader: ArticleImageUploadService) {
  }

  form = this._formBuilder.group({
    selector: [''],
    image: [null] 
  });

  onSubmit(){
    debugger;
    let formData = {
      title: this.form.value.selector,
      url: URL.createObjectURL(<any>this.selectedFile),
      image: this.selectedFile
    };

    this.uploadedData.emit(formData);
    this._imageuploader.closeUploader();
    this.selectedFile = null;
  }
  onFileSelected(args: any){
    debugger;
    const input = args.target as HTMLInputElement;

    if(input.files)
      this.selectedFile = Array.from(input.files)[0];
    
  }
  // uploadImages(): void{
  //   this.uploadedImage = {
  //     url: URL.createObjectURL(<any>this.selectedFile),
  //     name: this.selectedFile?.name || ''
  //   };

  //   //this.onUploadComplete.emit(this.uploadedImage.map(img => img.url));
  //   //this.selectedFile = [];

  //   this._imageuploader.closeUploader();
  // }
  
}
