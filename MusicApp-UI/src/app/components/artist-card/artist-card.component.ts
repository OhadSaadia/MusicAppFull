import { Component, OnInit ,Input } from '@angular/core';
import { Router } from '@angular/router';
import { Artist } from 'src/app/interfaces/Artist';
import { ArtistsService } from 'src/app/services/artists.service';
import { CountriesService } from 'src/app/services/countries.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-artist-card',
  templateUrl: './artist-card.component.html',
  styleUrls: ['./artist-card.component.css']
})
export class ArtistCardComponent implements OnInit {

  country ="";
  isFollowed: boolean = false;
  isUserConnected: boolean = false;

  constructor(private countriesService:CountriesService,
              private artistsService: ArtistsService,
              private usersService: UsersService,
              private router: Router) { }

  @Input() artist = {} as Artist
  ngOnInit(): void {
    this.getCountry(this.artist.coutryId);
    this.checkArtistIsFollowed(this.artist.id);
    this.isUserConnected = this.usersService.isAuthentical();
  }

  onDetailesClick(){  
    this.router.navigate([`/artist/${this.artist.id}`])
  }

  onFollowClick(){
    this.followOrUnfollowArtist();
  }

  getCountry(countryId:number){
    this.countriesService.getCountryName(countryId)
                          .subscribe((result: any) => this.country = result );
                      
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
