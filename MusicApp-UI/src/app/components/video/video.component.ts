import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeResourceUrl} from '@angular/platform-browser';
import { ActivatedRoute, Params } from '@angular/router';
import { Album } from 'src/app/interfaces/Album';
import { Publisher } from 'src/app/interfaces/Publisher';
import { Song } from 'src/app/interfaces/song';
import { AlbumsService } from 'src/app/services/albums.service';
import { GenreService } from 'src/app/services/genre.service';
import { PublisherService } from 'src/app/services/publisher.service';
import { SongsService } from 'src/app/services/songs.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.css']
})
export class VideoComponent implements OnInit {

  senitezedUrl: SafeResourceUrl = "";
  song: Song = {} as Song;
  songslist: Song[] = [];
  genreName:string = "";
  albumName: string = "";
  publisherName: string = "";
  isLiked: boolean = false;
  isConected: boolean = false;


  constructor(private activatedRoute: ActivatedRoute,
              private songsService: SongsService,
              private genreService: GenreService,
              private albumsService: AlbumsService,
              private usersService: UsersService,
              private publisherService: PublisherService,
              private sanitizer: DomSanitizer) {
                                
                      //Geting the route navigate params (id):
                      this.checkIsConnected();
                                
                      activatedRoute.params
                        .subscribe((params: Params) => {
                          songsService.getSong(params['id'])
                            .subscribe({
                              next: (result: any) => {
                                this.song = result;
                                this.getGenreName(this.song.genreId);
                                this.getAlbumName(this.song.albumId);
                                this.getPublisherName(this.song.publisherId);
                                this.getSanitizedUrl(this.song.youTubeSrc);
                                if (this.isConected) {
                                  this.checkSongIsLiked(this.song.id);
                                }
                              },
                              error: (err: any) => console.log(err)
                            });
                          });
                        
                        

                      //Geting the array of songs from local storage:
                    
                      const myArray = localStorage.getItem(SongsService.SONGS_KEY)
                      if (myArray === null) {
                        this.songslist = new Array<Song>();
                      } else {
                        this.songslist = JSON.parse(myArray);
                      }
                    
                        
  }                    

  ngOnInit(): void {

  }

  getSanitizedUrl(url : string){
    this.senitezedUrl = this.sanitizer.bypassSecurityTrustResourceUrl(url);
    
  }

  getGenreName(genreId:number){
    this.genreService.getGenreName(genreId)
                          .subscribe((result: any) => 
                          this.genreName = result );
                      
  }

  getAlbumName(albumId:number){
    this.albumsService.getAlbumName(albumId)
                          .subscribe((result: Album) => 
                          this.albumName = result.albumName);
                      
  }

  getPublisherName(publisherId:number){
    this.publisherService.getPublisherName(publisherId)
                          .subscribe((result: Publisher) => 
                          this.publisherName = result.companyName);
                      
  }

  likeOrUnlikeSong(){
    this.songsService.likeSong(this.song.id)
                        .subscribe((result) => this.isLiked = !this.isLiked);
  }

  checkSongIsLiked(songId:number){
    this.songsService.checkSongIsLiked(songId)
                        .subscribe((result:any) => this.isLiked = result);
  }

  checkIsConnected(){
    this.isConected = this.usersService.isAuthentical();
  }

  onLikeClick(){
    this.likeOrUnlikeSong();
  }

}


