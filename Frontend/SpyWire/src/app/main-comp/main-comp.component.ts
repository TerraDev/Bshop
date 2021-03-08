import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-main-comp',
  templateUrl: './main-comp.component.html',
  styleUrls: ['./main-comp.component.css']
})
export class MainCompComponent implements OnInit {

  constructor(public userService:UserService) { }
  CurrentUser;
  LogRegSelectedTab: number = 0;

  ngOnInit(): void {
    //this.ShowUsername();
  }

  logoutUser()
  {
    localStorage.removeItem('token');
    this.ShowUsername();
    //update name information
  }

  //Todo: implement interceptor
  ShowUsername($event?)
  {
    this.userService.getUserProfile().subscribe(
    res=> {
      this.CurrentUser = res;
    },
    err => {
      console.log(err);
      this.CurrentUser = null;
    })
  }

}
