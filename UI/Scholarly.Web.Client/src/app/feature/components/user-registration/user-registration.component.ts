import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, Validators, FormArray, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrl: './user-registration.component.css'
})
export class UserRegistrationComponent {
  userId:number = 1;
  private urls = {
    saveUser: '/user/save',
    saveEducation: '/user/education',
    saveWorkExperience: 'user/workexperience'
  };
  constructor(private formBuilder: FormBuilder,private httpClient: HttpClient) {
  }
  userRegistrationForm = this.formBuilder.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    userName: [''],
    email: ['', Validators.required],
    phoneNumber: [''],
    dob: [''],
    password: ['', Validators.required],
    genderId: ['']
  });
  userEducationForm = this.formBuilder.group({
    userEducation: this.formBuilder.array([this.createEducation()])
  });
  get userEducation():FormArray{
    return this.userEducationForm.get('userEducation') as FormArray;
  }
  createEducation():FormGroup{
    return this.formBuilder.group({
      userId: [this.userId],
      educationName: ['', Validators.required],
      fieldOfStudy: ['', Validators.required],
      level: ['', Validators.required],
      instituteName: ['', Validators.required],
      startDt: [new Date(), Validators.required],
      endDt: [new Date(), Validators.required],
      isCurrent: [false]
    });
  }
  addEducation(){
    this.userEducation.push(this.createEducation());
  }
  userWorkExperienceForm = this.formBuilder.group({
    userWorkExperience: this.formBuilder.array([this.createWorkExperience()])
  });
  get userWorkExperience():FormArray{
    return this.userWorkExperienceForm.get('userWorkExperience') as FormArray;
  }
  createWorkExperience(){
    return this.formBuilder.group({
      userId: [this.userId],
      position: ['', Validators.required],
      startDt: ['', Validators.required],
      endDt: ['', Validators.required],
      isCurrent: [false],
      skillsUsed: ['', Validators.required],
      companyName: ['', Validators.required],
      description: ['']
    });
  }
  addWorkExperience(){
    this.userWorkExperience.push(this.createWorkExperience());
  }
  saveUser(){
    this.httpClient.post(this.urls.saveUser, this.userRegistrationForm.value).subscribe(
      (response:any)=>{
        console.log(response);
        this.userId = response.userId;
      },
      (error)=>{
        console.log(error);
      }
    );
  }
  saveEducation(){
    this.httpClient.post(this.urls.saveEducation, this.userEducationForm.value.userEducation).subscribe(
      (response)=>{
        console.log(response);
      },
      (error)=>{
        console.log(error);
      }
    )
  }
  
  saveWorkExperience(){
    console.log(this.userWorkExperienceForm.value);
    this.httpClient.post(this.urls.saveWorkExperience, this.userWorkExperienceForm.value.userWorkExperience).subscribe(
      (response)=>{
        console.log(response);
      },
      (error)=>{
        console.log(error);
      }
    )
  }
}
