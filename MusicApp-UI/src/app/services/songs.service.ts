import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Song } from '../interfaces/song';
import { UsersService } from './users.service';

@Injectable({
  providedIn: 'root'
})
export class SongsService {
  
  public static readonly SONGS_KEY = "songs";
  public static readonly ALBUM_SONGS_KEY = "album-songs";
  server: string = "https://localhost:44321/api/songs";
  
  constructor(private http: HttpClient,
    private usersService: UsersService) { }
    
    getAllSongs() {
      return this.http.get(`${this.server}`);
  }
  
  getSong(id: number) {
    return this.http.get(`${this.server}/${id}`);
  }
  
  get10Random() {
    return this.http.get<Song[]>(`${this.server}/10random`);
  }
  get10MostLiked() {
    return this.http.get<Song[]>(`${this.server}/10mostliked`);
  }
  get10TopPlayed() {
    return this.http.get<Song[]>(`${this.server}/10topplayed`);
  }

  getLikedSongs() {
    
    let httpOptions =this.getAuthHeader();
    
    if (httpOptions) {
      return this.http.get<Song[]>(`${this.server}/likes`,httpOptions);
    }
    else throw new Error();
  }
  
  getListeningHistory() {
    
    let httpOptions = this.getAuthHeader();
    
    if (httpOptions) {
      return this.http.get<Song[]>(`${this.server}/listeninghistory`, httpOptions);
    }
    else throw new Error();
  }
  
  getAlbumSongs(albumId: any) {
    return this.http.get<Song[]>(`${this.server}/album?albumid=${albumId}`);
  }
  
  getArtistSongs(artistId: string) {
    return this.http.get<Song[]>(`${this.server}/artist?artistid=${artistId}`);
  }
  
  searchSong(songName: string) {
    return this.http.get<Song[]>(`${this.server}/search?songName=${songName}`);
  }
  
  postToSongLog(songId:number){
    
    let httpOptions = this.getAuthHeader();
    
    if (httpOptions) {
      let newHttpOptions = {...httpOptions,responseType :'text' as const};
      return this.http.post(`${this.server}/songlog`,{songId:songId}, newHttpOptions);
    }else throw new Error();
  }
  
  getSongsByArtist(artistId : number){
    return this.http.get<Song[]>(`${this.server}/artist?artistid=${artistId}`)
  }
  
  checkSongIsLiked(songId: number) {
    let httpOptions = this.getAuthHeader();

    if (httpOptions) {
      return this.http.get<{isliked:boolean}>(`${this.server}/isliked?songid=${songId}`, httpOptions);
    }else throw new Error();
  }

  likeSong(id: number) {
    let httpOptions = this.getAuthHeader();

    if (httpOptions) {
      let newHttpOptions = {...httpOptions,responseType :'text' as const};
      return this.http.post(`${this.server}/likes`,{songId:id}, newHttpOptions);
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
