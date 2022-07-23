import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CountriesService {


  server: string = "https://localhost:44321/api/countries";

  constructor(private http:HttpClient) {}

  getCountryName(id:number){
    return this.http.get(`${this.server}/${id}`, {responseType: 'text'})
  }
  
}
