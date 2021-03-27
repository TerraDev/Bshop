import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {


  loginForm: FormGroup = new FormGroup({});

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: '',  //or username??
      password: '',
    });

    this.loginForm.valueChanges.subscribe(console.log);
  }

  onSubmit(): void {
    if(this.loginForm.valid)
    {
      console.log("form submitted!");
      this.loginForm.reset();
    }
  }
}