import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Artist } from '../interfaces/Artist';
import { UsersService } from './users.service';

@Injectable({
  providedIn: 'root'
})
export class ArtistsService {


  public static readonly ARTISTS_KEY = "artists";

  server : string = "https://localhost:44321/api/artists" ;

  constructor(private http : HttpClient) { }

  getArtist(id:number){
      return this.http.get<Artist>(`${this.server}/${id}`);  
  }

  searchArtists(stageName:string){
    return this.http.get<Artist[]>(`${this.server}/search?artist=${stageName}`);
  }

  getAllArtists(){
    return this.http.get<Artist[]>(`${this.server}`)
  }

  getLikedArtists() {

    let httpOptions =this.getAuthHeader();

    if (httpOptions) {
        return this.http.get<Artist[]>(`${this.server}/likes`,httpOptions);
    }
    else throw new Error();
  }

  countFollowersByArtist(artistId:number){
    return this.http.get(`${this.server}/countfollowers?artistid=${artistId}`);
  }

  followArtist(artistId:number){

    let httpOptions = this.getAuthHeader();

    if (httpOptions) {
      let newHttpOptions = {...httpOptions,responseType :'text' as const};
      return this.http.post(`${this.server}/likes`,{artistId:artistId}, newHttpOptions);
    }else throw new Error();
  }

  checkArtistIsFollowed(artistId:number){

    let httpOptions = this.getAuthHeader();

    if (httpOptions) {
      return this.http.get<{isliked:boolean}>(`${this.server}/isliked?artistid=${artistId}`, httpOptions);
    }else throw new Error();
  }


  getAuthHeader(){
    let token = localStorage.getItem(UsersService.TOKEN_KEY);

    if (token) {
     return {
        headers: new HttpHeaders().set(`Authorization`, `Bearer ${token}`)
      };
    } 
    else{
      localStorage.clear();
      return null; 
    }
  }
  
}
