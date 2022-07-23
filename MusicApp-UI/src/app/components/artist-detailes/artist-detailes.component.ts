import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Album } from 'src/app/interfaces/Album';
import { Artist } from 'src/app/interfaces/Artist';
import { Song } from 'src/app/interfaces/song';
import { AlbumsService } from 'src/app/services/albums.service';
import { ArtistsService } from 'src/app/services/artists.service';
import { CountriesService } from 'src/app/services/countries.service';
import { SongsService } from 'src/app/services/songs.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-artist-detailes',
  templateUrl: './artist-detailes.component.html',
  styleUrls: ['./artist-detailes.component.css']
})
export class ArtistDetailesComponent implements OnInit {
  artist: Artist = {} as Artist;
  countryName: string = "";
  allArtistSongs: Song[] = []; 
  albums: Album[] = [];
  followersCount: number = 0;
  isFollowed: any;
  isUserConnected: any;
 

  constructor(private router: Router,
              private activatedRoute: ActivatedRoute,
              private usersService: UsersService,
              private artistsService: ArtistsService,
              private countryService: CountriesService,
              private songsService: SongsService,
              private albumsService: AlbumsService) {

                                      //Geting the route navigate params (id):
                                                    
                                      activatedRoute.params
                                      .subscribe((params: Params) => {
                                        artistsService.getArtist(params['id'])
                                          .subscribe({
                                            next: (result: any) => {
                                              this.artist = result;
                                              this.getCountryName(this.artist.coutryId); 
                                              this.getAllAlbums(this.artist.id); 
                                              this.getAllArtistSongs(this.artist.id); 
                                              this.countAllFollowers(this.artist.id);
                                              this.checkArtistIsFollowed(this.artist.id)
                                              this.isUserConnected = this.usersService.isAuthentical();
                                            },
                                            error: (err: any) => console.log(err)
                                          });
                                        });

   }

  ngOnInit(): void {
  }

  onFollowClick(){
    this.followOrUnfollowArtist();
  }

  getCountryName(countryId:number){
    this.countryService.getCountryName(countryId)
                          .subscribe((result: any) => 
                          this.countryName = result );
                      
  }

  getAllAlbums(artistId:number){
    this.albumsService.getAlbumsByArtist(artistId)
                          .subscribe((result: Album[]) => 
                          this.albums = result );
                      
  }

  getAllArtistSongs(artistId:number){
    this.songsService.getSongsByArtist(artistId)
                          .subscribe((result: Song[]) => 
                          this.allArtistSongs = result );
                      
  }

  countAllFollowers(artistId:number){
    this.artistsService.countFollowersByArtist(artistId)
                        .subscribe((result:any) => this.followersCount = result);
  }

  followOrUnfollowArtist(){
    this.artistsService.followArtist(this.artist.id)
                        .subscribe((result) => this.isFollowed = !this.isFollowed);
  }

  checkArtistIsFollowed(artistId:number){
    this.artistsService.checkArtistIsFollowed(artistId)
                        .subscribe((result:any) => this.isFollowed = result);
  }

}
