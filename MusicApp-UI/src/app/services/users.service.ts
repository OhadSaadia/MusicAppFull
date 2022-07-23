import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SignUpModel } from '../interfaces/SignUpModel';
import { User } from '../interfaces/user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
 
  server : string = "https://localhost:44321/api/accounts";
  public static readonly EMAIL_KEY = 'email';
  public static readonly TOKEN_KEY = 'token';
  public static readonly LOGIN_KEY = 'login';
  
  constructor(private http:HttpClient) { }

  getAllUsers(){
    return this.http.get(`${this.server}`);
  }

  getUser(email:string){

    let token = localStorage.getItem(UsersService.TOKEN_KEY);

    if (token) {
      let httpOptions = {
        headers: new HttpHeaders().set(`Authorization`, `Bearer ${token}`)
      };
      return this.http.get<User>(`${this.server}/user`,httpOptions);
    }
    else throw new Error();
  }

  login(email:string , password:string){
    
    password = "A~"+password+"b";
    return this.http.post(`${this.server}/signin` ,{email,password},  {responseType: 'text'});
  }

  signUp(signUpModel:SignUpModel){
    signUpModel.password = "A~"+signUpModel.password+"b";
    signUpModel.confirmPassword = "A~"+signUpModel.confirmPassword+"b";
    return this.http.post(`${this.server}/signup` ,signUpModel,{responseType: 'text'});

  }


  isAuthentical() : boolean {
    let email = localStorage.getItem('email');
    return (email !== null);
  }

  
}
