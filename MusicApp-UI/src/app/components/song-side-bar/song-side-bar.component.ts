import { Component, Input, OnInit } from '@angular/core';
import { Song } from 'src/app/interfaces/song';
import { SongsService } from 'src/app/services/songs.service';
import { NavigationExtras, Router } from '@angular/router';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-song-side-bar',
  templateUrl: './song-side-bar.component.html',
  styleUrls: ['./song-side-bar.component.css']
})
export class SongSideBarComponent implements OnInit {

  isConnected: boolean = false;

  @Input() songs:Song[] =  [];
  @Input() selectedSongId :number = 0;
  constructor(private songService:SongsService,
              private usersService: UsersService,
              private router:Router) {
                
                this.checkIsConnected();
             
 }
   
  ngOnInit(): void {
   
  }


  onClick(song:Song){
    
    if (this.isConnected) {
      this.songService.postToSongLog(song.id)
                    .subscribe({
                      next: (msg:any) => console.log(msg),
                      error: (err:any) => console.log(err)
                    });
    }
    
    
    if (localStorage.getItem(SongsService.SONGS_KEY) != null) {
      localStorage.removeItem(SongsService.SONGS_KEY);
    }
    localStorage.setItem(SongsService.SONGS_KEY, JSON.stringify(this.songs));

    this.selectedSongId = song.id;
    this.router.navigate([`/video/${song.id}`]);
  }

  checkIsConnected() {
    this.isConnected = this.usersService.isAuthentical();
  }
}