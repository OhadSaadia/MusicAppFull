import { Component, OnDestroy, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { Artist } from 'src/app/interfaces/Artist';
import { ArtistsService } from 'src/app/services/artists.service';
import { CountriesService } from 'src/app/services/countries.service';

@Component({
  selector: 'app-artists-cards',
  templateUrl: './artists-cards-list.component.html',
  styleUrls: ['./artists-cards-list.component.css']
})
export class ArtistsCardsListComponent implements OnInit , OnDestroy{

  artists : Artist[] = [];
  reloadSubscription: any;
  title: string ="";


  constructor(private router : Router,
              private artistsService: ArtistsService, 
              private countriesService: CountriesService,) 
  {

                if (router.url === '/likedartists') {
                  this.getLikedArtistsFromService();
                  this.title = "Liked Artists";
                }
                if (router.url === '/search/artists') {
                  const myArray = localStorage.getItem(ArtistsService.ARTISTS_KEY);
                  if (myArray === null) {
                    this.artists = new Array<Artist>();
                  } else {
                    this.artists = JSON.parse(myArray);
                  }
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

  getLikedArtistsFromService() {
    try {
      this.artistsService.getLikedArtists()
                       .subscribe({
                            next: (res : Artist[]) => { 
                              this.artists = res;                   
                            },
                            error: (err : any) =>{
                              this.artists = {} as Artist[];
                                       
                            }                
                        });
    } 
    catch (error) {
    console.log(error);
    }
  }

  
}
