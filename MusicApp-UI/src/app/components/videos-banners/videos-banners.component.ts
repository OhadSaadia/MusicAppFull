import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { Song } from 'src/app/interfaces/song';
import { ArtistsService } from 'src/app/services/artists.service';
import { SongsService } from 'src/app/services/songs.service';

@Component({
  selector: 'app-videos-banners',
  templateUrl: './videos-banners.component.html',
  styleUrls: ['./videos-banners.component.css']
})
export class VideosBannersComponent implements OnInit , OnDestroy{

  title:string ="";
  songsId: number[] = [];
  songs: Song[] = [];
  reloadSubscription:any = {};

  constructor(private router: Router,
              private activatedRoute: ActivatedRoute,
              private songsService: SongsService,
              public artistsService : ArtistsService) {

                       if (router.url === '/likedsongs') {
                              this.getLikedSongsFromService();
                              this.title = "Liked Songs";
                       }
                       if(router.url === '/listeninghistory'){
                              this.getListeningHistoryFromService();
                              this.title = "Listening History";
                       }
                       if(router.url === '/search/songs'){
                              this.getSearchSongResults();
                              this.title = "";
                       }
                       if(router.url.split('/')[1] === 'album'){
                        this.getAlbumSongs();
                        this.title = "Album songs";
                       }
                       if (router.url.split('/')[1] === 'artistsongs') {
                        this.getArtistSongs();
                        this.title = "Artist songs";
                       }
                        
                       


                       this.router.routeReuseStrategy.shouldReuseRoute = function () {
                        return false;
                      };
                      this.reloadSubscription = this.router.events.subscribe((event) => {
                        if (event instanceof NavigationEnd) {
                          this.router.navigated = false;
                        }
                      });
  }
  ngOnDestroy(): void {
    if (this.reloadSubscription) {
      this.reloadSubscription.unsubscribe();
    }
  }
  
  ngOnInit(): void {
    
  }
  
  getLikedSongsFromService(){
    try {
        this.songsService.getLikedSongs()
                         .subscribe({
                              next: (res:Song[]) => {
                                this.songs = res;
                                localStorage.setItem(SongsService.SONGS_KEY, JSON.stringify(this.songs));
                              },
                              error: (err:string) => console.log(err)                      
        });
    } catch (error) {
      console.log(error);
    }
  }

  getListeningHistoryFromService(){
    try {
        this.songsService.getListeningHistory()
                          .subscribe({
                            next: (res:Song[]) => {
                              this.songs = res;
                              localStorage.setItem(SongsService.SONGS_KEY, JSON.stringify(this.songs));
                            },
                            error: (err:any) => console.log(err)    
                          })
    } catch (error) {
      
    }
  }

  getSearchSongResults(){
     let result = localStorage.getItem(SongsService.SONGS_KEY);
     if (result) {
       this.songs = JSON.parse(result);
      }else throw new Error();
    }

  getAlbumSongs() {
        this.songsService.getAlbumSongs(this.router.url.split('/')[2])
                         .subscribe({
                          next: (res:Song[]) => {
                            this.songs = res;
                            localStorage.setItem(SongsService.SONGS_KEY, JSON.stringify(this.songs));
                          },
                          error: (err:any) => console.log(err)  
                         })
      }
  
  getArtistSongs() {
    this.songsService.getArtistSongs(this.router.url.split('/')[2])
                     .subscribe({
                      next: (res:Song[]) => {
                        this.songs = res;
                        localStorage.setItem(SongsService.SONGS_KEY, JSON.stringify(this.songs));
                      },
                      error: (err:any) => console.log(err)  
                     })
  }
  
}

  
  