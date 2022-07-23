import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Artist } from 'src/app/interfaces/Artist';
import { Song } from 'src/app/interfaces/song';
import { ArtistsService } from 'src/app/services/artists.service';
import { SongsService } from 'src/app/services/songs.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchText:string = "";
  searchBy:string = "Song";

  constructor(private songsService : SongsService ,
              private artistsService :ArtistsService,
              private router:Router) { }

  ngOnInit(): void {
  }

  onSubmit(){

  }

  onSearch(data : any){
      if(data.searchBy === 'Song'){
        this.songsService.searchSong(data.searchText)
                          .subscribe({
                            next: (res : Song[]) => { 
                              localStorage.setItem(SongsService.SONGS_KEY, JSON.stringify(res));                                
                              this.router.navigate(['search/songs'])
                            },
                            error: (err : any) =>{
                              localStorage.removeItem(SongsService.SONGS_KEY);
                              this.router.navigate(['search/songs'])       
            }
        });
      }
      if(data.searchBy === 'Artist'){
          this.artistsService.searchArtists(data.searchText)
                              .subscribe({
                                next: (res : Artist[]) => { 
                                  localStorage.setItem(ArtistsService.ARTISTS_KEY, JSON.stringify(res));                                
                                  this.router.navigate(['search/artists'])
                                            
                                  },
                                error: (err : any) =>{
                                  localStorage.removeItem(ArtistsService.ARTISTS_KEY);
                                  this.router.navigate(['search/artists'])
                                           
                                } 
                              });
      }
  }
}
