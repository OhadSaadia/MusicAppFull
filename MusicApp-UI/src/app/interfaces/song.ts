import { SafeResourceUrl } from "@angular/platform-browser";
import { Artist } from "./Artist";

export interface Song {
    id: number;
    name: string;
    artistId: number;
    watched: number;

    duration: Date;
    publisherId: number;
    datePublished: Date;
    albumId: number;
    genreId: number;

    youTubeSrc: string;
    imageSrc: string;
    
    artist: Artist;
}