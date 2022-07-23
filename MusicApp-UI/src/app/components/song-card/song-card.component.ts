import { Component, Input, OnInit } from '@angular/core';
import { Router } from  '@angular/router';
import { Song } from 'src/app/interfaces/song';
import { GenreService } from 'src/app/services/genre.service';
import { SongsService } from 'src/app/services/songs.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-song-card',
  templateUrl: './song-card.component.html',
  styleUrls: ['./song-card.component.css']
})
export class SongCardComponent implements OnInit {

  genreName = "";
  isUserConnected: boolean = false;
  isLiked: boolean = false;
  defaultSongPic = "../../../assets/images/defaultSongPic.jpg";
  constructor(private genreService:GenreService,
              private songsService:SongsService,
              private usersService:UsersService,
              private router:Router){ }

  @Input() song = {} as Song
  @Input() songsList: Song[] = [];
  ngOnInit(): void {
    this.getGenreName(this.song.genreId);
    this.checkSongIsLiked(this.song.id);
    this.isUserConnected = this.usersService.isAuthentical();
  }

  getGenreName(genreId:number){
    this.genreService.getGenreName(genreId)
                          .subscribe((result: any) => 
                          this.genreName = result );
                      
  }

  onBannerClick(){

    if (localStorage.getItem(SongsService.SONGS_KEY) != null) {
      localStorage.removeItem(SongsService.SONGS_KEY);
    }
    localStorage.setItem(SongsService.SONGS_KEY, JSON.stringify(this.songsList));

    if (this.isUserConnected){
      this.songsService.postToSongLog(this.song.id)
      .subscribe({
        next: (msg:any) => this.router.navigate([`/video/${this.song.id}`]),
        error: (err:any) => this.router.navigate([`/server-error`])
      });
    }
    else{
      this.router.navigate([`/video/${this.song.id}`])
    }
      
   
  }

  
  likeOrUnlikeSong(){
    this.songsService.likeSong(this.song.id)
                        .subscribe((result) => this.isLiked = !this.isLiked);
  }

  checkSongIsLiked(songId:number){
    this.songsService.checkSongIsLiked(songId)
                        .subscribe((result:any) => this.isLiked = result);
  }

  onLikeClick(){
    this.likeOrUnlikeSong();
  }
}
