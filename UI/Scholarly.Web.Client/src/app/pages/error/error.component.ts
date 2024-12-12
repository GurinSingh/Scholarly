import { Component, inject, OnInit } from '@angular/core';
import { errorResponse } from '../../core';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrl: './error.component.css'
})
export class ErrorComponent implements OnInit {
  public error:errorResponse = <errorResponse>{};
 
  ngOnInit(): void {
    this.error = history.state.error;

    if(this.error == undefined || this.error == null)
      this.error = {
        statusCode: 0,
        message: 'Unknown error has occurred.',
        title: 'Error not known'
      };
  }
}
