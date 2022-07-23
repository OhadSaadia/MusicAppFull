import { Song } from "./song";

export interface Album {
    id : number;
    albumName:string;
    artistId :string;
    datePublished : Date;
    songs : Song[];

}