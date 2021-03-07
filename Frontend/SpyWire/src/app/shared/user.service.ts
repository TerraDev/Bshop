import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from './user.model';
import { loginUser } from './loginUser.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private Http : HttpClient) { }

  readonly RegisterUrl = 'http://localhost:63825/User/Register';
  readonly UserProfileUrl = 'http://localhost:63825/User/Profile';
  readonly LoginUrl = 'http://localhost:63825/User/Login';
  UserData : User = new User();
  LoginUserData : loginUser = new loginUser();

  RegisterUser()
  {
    return this.Http.post(this.RegisterUrl, this.UserData);
  }

  LoginUser()  //Getuser() ??
  {
    console.log(this.LoginUserData);
    var x = this.Http.post(this.LoginUrl, this.LoginUserData);
    console.log(x);
    return x;
  }

  getUserProfile()
  {
    var tokenHeader = new HttpHeaders({'Authorization':'Bearer '+ localStorage.getItem('token')});
    return this.Http.get(this.UserProfileUrl, {headers:tokenHeader});
  }


}