import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule  } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { SearchComponent } from './components/search/search.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { VideoComponent } from './components/video/video.component';
import { SongSideBarComponent } from './components/song-side-bar/song-side-bar.component';
import { SideMenuComponent } from './components/side-menu/side-menu.component';
import { VideosBannersComponent } from './components/videos-banners/videos-banners.component';
import { PlaylistsComponent } from './components/playlists/playlists.component';
import { ArtistsCardsListComponent } from './components/artists-cards-list/artists-cards-list.component';
import { HomeMenuPageComponent } from './components/home-menu-page/home-menu-page.component';
import { ServerErrorComponent } from './components/server-error/server-error.component';
import { ArtistCardComponent } from './components/artist-card/artist-card.component';
import { SongCardComponent } from './components/song-card/song-card.component';
import { ArtistDetailesComponent } from './components/artist-detailes/artist-detailes.component';
import { AlbumCardComponent } from './components/album-card/album-card.component';
import { AuthGuardService } from './services/auth-guard.service';
import { AlbumsCardsListComponent } from './components/albums-cards-list/albums-cards-list.component';
import { AddNewSongComponent } from './components/add-new-song/add-new-song.component';
import { AddNewAlbumComponent } from './components/add-new-album/add-new-album.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';

const routes : Routes = [
  {
    path : '' , 
    component : HomeComponent ,
    children : [
      {path: '' , component : HomeMenuPageComponent},
      {path : 'video/:id' , component: VideoComponent},
      {path: 'likedartists' , component : ArtistsCardsListComponent , canActivate : [AuthGuardService]},
      {path : 'likedsongs' , component : VideosBannersComponent, canActivate : [AuthGuardService]},
      {path : 'listeninghistory' , component : VideosBannersComponent, canActivate : [AuthGuardService]},
      {path : 'album/:id' , component : VideosBannersComponent},
      {path : 'artistsongs/:id' , component : VideosBannersComponent},
      {path : 'search/songs' , component : VideosBannersComponent},
      {path : 'playlists' , component : PlaylistsComponent},
      {path : 'artistalbums/:id' , component : AlbumsCardsListComponent},
      {path : 'search/artists' , component : ArtistsCardsListComponent},
      {path : 'artist/:id' , component : ArtistDetailesComponent},
      {path : 'addnewsong' , component : AddNewSongComponent},

      
    ]
  },
  {path : 'login' , component : LoginComponent },
  {path : 'signup' , component : SignUpComponent },
  {path : 'server-error' , component : ServerErrorComponent },

 
]


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    SearchComponent,
    VideoComponent,
    SongSideBarComponent,
    SideMenuComponent,
    VideosBannersComponent,
    PlaylistsComponent,
    ArtistsCardsListComponent,
    ServerErrorComponent,
    ArtistCardComponent,
    SongCardComponent,
    ArtistDetailesComponent,
    AlbumCardComponent,
    AlbumsCardsListComponent,
    AddNewSongComponent,
    AddNewAlbumComponent,
    SignUpComponent,
    HomeMenuPageComponent,    
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    RouterModule.forRoot(routes , {onSameUrlNavigation: 'reload'}),
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
