import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, Validators, FormArray, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-write-content',
  templateUrl: './write-content.component.html',
  styleUrl: './write-content.component.css'
})
export class WriteContentComponent {
  private urls = {
    saveContent: '/content/save',
  };
  constructor(private formBuilder: FormBuilder,private httpClient: HttpClient){}
  
  writeContentForm = this.formBuilder.group({
    contentTitle: ['', Validators.required],
    contentDescription: ['', Validators.required]
  });

  saveContent(){
    this.httpClient.post(this.urls.saveContent, this.writeContentForm.value).subscribe(
      (response:any)=>{
        console.log(response);
      },
      (error)=>{
        console.log(error);
      }
    );
  }
}
