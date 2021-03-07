import { Component, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import{ EventEmitter } from '@angular/core'
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/shared/user.model';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(public userService:UserService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  RegisterForm(form : NgForm)
  {
    this.userService.RegisterUser().subscribe(
      res => {
        //this.LoginForm(form);
        this.resetForm(form);
        this.toastr.success('Registered Successfully');
      },
      err => {
        this.toastr.error('Registration failed');
        console.log(err)
      }
    )
  }


  @Output() LoginEvent= new EventEmitter();
  LoginForm(form : NgForm)
  {
    this.userService.LoginUser().subscribe(
      res => {

        //get token
        (res: any) => {
          //console.log(res.token)
          localStorage.setItem('token', res.token)
        }

        this.resetForm(form);
        this.toastr.success('Signed in Successfully','you are Logged in');
        //todo: close the modal
        this.LoginEvent.emit('');
      },
      err => {
        if (err.status == 400)
          this.toastr.error('Incorrect username or password.', 'Authentication failed.');
        else
          console.log(err);
      }
    )
  }


  resetForm(form: NgForm): void
  {
    form.form.reset();
    this.userService.UserData = new User();
  }
  //Logout???

}
