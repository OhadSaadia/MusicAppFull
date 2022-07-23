import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Publisher } from '../interfaces/Publisher';

@Injectable({
  providedIn: 'root'
})
export class PublisherService {

  server: string = "https://localhost:44321/api/publishers";

  constructor(private http: HttpClient) { }

  getPublisherName(id:number){
    return this.http.get<Publisher>(`${this.server}/${id}`)
  }


}
