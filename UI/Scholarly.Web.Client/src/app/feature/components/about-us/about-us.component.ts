import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { user } from '../../models/about-us/feature.user.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrl: './about-us.component.css',
})
export class AboutUsComponent implements OnInit {
  private url:string = "/user";
  public user:user = <any>{};
  
  
  constructor(private http:HttpClient,private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params=>{
      let userName:string | null = params.get('userName');

      if(userName != null)
        this.url+="/"+userName;

      this.getUserInformation();
    });

  }

  getUserInformation(){
    this.http.get<user>(this.url).subscribe({
      next: (value: user)=>{
        this.user = value;
        this.user.workExperiences.forEach(e=>{
          e.startDt = new Date(e.startDt);
          e.endDt = new Date(e.endDt);
        });
        this.user.educations.forEach(e=>{
          e.startDt = new Date(e.startDt);
          e.endDt = new Date(e.endDt);
        });
      },
      error: (err:any)=>{
        console.log(err);
      }
    });
  }
}
