import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from 'src/app/services/users.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  isAuthentical : boolean = false;

  constructor(private usersService:UsersService,
                private router : Router) { }

  ngOnInit(): void {
  }

  onLogin(data : any){
    this.isAuthentical=true;
    this.usersService.login(data.email , data.password)
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
                            throw new Error('not authenticated')
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
