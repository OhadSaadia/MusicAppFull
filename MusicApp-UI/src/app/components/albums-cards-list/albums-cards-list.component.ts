import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Album } from 'src/app/interfaces/Album';
import { AlbumsService } from 'src/app/services/albums.service';


@Component({
  selector: 'app-albums-cards-list',
  templateUrl: './albums-cards-list.component.html',
  styleUrls: ['./albums-cards-list.component.css']
})
export class AlbumsCardsListComponent implements OnInit {

  title : string = "Albums";
  albums: Album[] = [];


  constructor(private albumsService : AlbumsService,
              private router: Router) {

                this.getArtistAlbums();
  }

  ngOnInit(): void {
  }

  getArtistAlbums() {
    this.albumsService.getAlbumsByArtist(+this.router.url.split('/')[2]).subscribe(
      (albums: Album[]) => {
        this.albums = albums;
      } 
    );
  }

}
