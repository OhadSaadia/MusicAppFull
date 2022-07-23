import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {NgbOffcanvas, OffcanvasDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { User } from 'src/app/interfaces/user';
import { UsersService } from 'src/app/services/users.service';




@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.css']
})
export class SideMenuComponent implements OnInit {

  closeResult ='';
  userConected : User = {} as User;

 
  constructor(private offCanvasService: NgbOffcanvas,
              private userService:UsersService,
              private router : Router) { 
               
              }

  ngOnInit(): void {
    let email = localStorage.getItem(UsersService.EMAIL_KEY);
    if (email) {
       this.userService.getUser(email)
                  .subscribe({
                    next: (result:User) => {       
                      this.userConected = result;
                    },
                    error: (err:any) => {
                      console.error('my..' , err)
                      this.userConected = {} as User;    
                      this.onLogout();
                    }
                  });
    }          
  }

  open(content : any){
    this.offCanvasService.open(content , {ariaLabelledBy : 'offcanvas-basic-title'})
                          .result.then((resulte:any) =>{
                            this.closeResult = `Closed with : ${resulte}`;
                          }, (reason : any) => {
                            this.closeResult = `Dismissed ${this.getDismissReason(reason)}`
                          });
  }

  private getDismissReason(reason:any):string {
    if(reason === OffcanvasDismissReasons.ESC){
      return 'by pressing ESC';      
    }else if (reason === OffcanvasDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on the backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  onLogout(){
    localStorage.clear();
    window.location.reload();
    
  }
}

