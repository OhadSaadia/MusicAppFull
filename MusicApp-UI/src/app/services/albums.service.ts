import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Album } from '../interfaces/Album';

@Injectable({
  providedIn: 'root'
})
export class AlbumsService {

  server: string = "https://localhost:44321/api/albums";
  

  constructor(private http : HttpClient) { }

  getAlbumName(id:number){
    return this.http.get<Album>(`${this.server}/${id}`)
  }

  getAlbumsByArtist(artistId : number){
    return this.http.get<Album[]>(`${this.server}/artist?artistid=${artistId}`)
  }
}
