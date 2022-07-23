import { Component, Input, OnInit } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { Album } from 'src/app/interfaces/Album';
import { SongsService } from 'src/app/services/songs.service';

@Component({
  selector: 'app-album-card',
  templateUrl: './album-card.component.html',
  styleUrls: ['./album-card.component.css']
})
export class AlbumCardComponent implements OnInit {

  @Input() album = {} as Album;
  constructor(private router: Router) { }
  
  ngOnInit(): void {
  }

  onBannerClick(){
    this.router.navigate(['/album', this.album.id]);

  }

}
