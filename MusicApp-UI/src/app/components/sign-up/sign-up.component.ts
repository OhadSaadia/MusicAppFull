import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  isAuthentical : boolean = false;

  constructor(private usersService:UsersService,
                private router : Router) { }

  ngOnInit(): void {
  }

  onSignUp(data : any){
    this.isAuthentical=true;
    this.usersService.signUp(data)
                      .subscribe({
                        next: (resulte:any) => {                                                 
                          if (resulte)  {
                            this.isAuthentical = true;
                            localStorage.setItem(UsersService.EMAIL_KEY,data.email);
                            localStorage.setItem(UsersService.TOKEN_KEY,resulte);
                            this.router.navigate(['/']);
                          }
                          else{
                            localStorage.clear();
                            this.isAuthentical = false;
                          }
                        },    
                        error: (err:any) => {
                          console.error("my" ,err)  ;
                          localStorage.clear();
                          this.router.navigate(['server-error']); 
                        }          
                      })
  }

}
