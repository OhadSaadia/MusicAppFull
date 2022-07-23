import { Component, OnInit } from '@angular/core';
import { Song } from 'src/app/interfaces/song';
import { SongsService } from 'src/app/services/songs.service';

@Component({
  selector: 'app-home-menu-page',
  templateUrl: './home-menu-page.component.html',
  styleUrls: ['./home-menu-page.component.css']
})
export class HomeMenuPageComponent implements OnInit {

  topPlayed: Song[] = [];
  mostLiked: Song[] = [];
  random: Song[] = [];

  constructor(private songsService : SongsService) { }

  ngOnInit(): void {
    this.getTopPlayed();
    this.getMostLiked();
    this.getRandom();
  }

  getTopPlayed() {
    this.songsService.get10TopPlayed().subscribe(
      (data: Song[]) => {
        this.topPlayed = data;
      }
    );
  }

  getMostLiked() {
    this.songsService.get10MostLiked().subscribe(
      (data: Song[]) => {
        this.mostLiked = data;
      }
    );
  }

  getRandom() {
    this.songsService.get10Random().subscribe(
      (data: Song[]) => {
        this.random = data;
      }
    );
  }


}
