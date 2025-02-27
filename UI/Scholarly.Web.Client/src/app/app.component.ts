import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { APP_SUB_ROUTES } from './core/constants/APP_ROUTES';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient) {
  }

  title = 'Scholarly.Web.Client';

  
}
