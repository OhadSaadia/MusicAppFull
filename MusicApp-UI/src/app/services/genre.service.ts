import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  server: string = "https://localhost:44321/api/genres";

  constructor(private http : HttpClient) { }


  getGenreName(id:number){
    return this.http.get(`${this.server}/${id}`, {responseType: 'text'})
  }
}
