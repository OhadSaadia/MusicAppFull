import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  isConnected = false;
 
  constructor(public usersService:UsersService) {
    this.isConnected = this.usersService.isAuthentical();



   }

  ngOnInit(): void {
  }

}
