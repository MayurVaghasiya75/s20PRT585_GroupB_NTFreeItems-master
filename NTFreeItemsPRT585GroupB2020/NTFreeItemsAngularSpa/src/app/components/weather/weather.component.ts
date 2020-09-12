import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss']
})
export class WeatherDataComponent {
  public forecasts: WeatherForecast[];
  baseUrl: string;
  constructor(http: HttpClient 
    //, @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = `https://127:0:0:1:5001`;
    http.get<WeatherForecast[]>(`/api/weatherforecast`).subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
