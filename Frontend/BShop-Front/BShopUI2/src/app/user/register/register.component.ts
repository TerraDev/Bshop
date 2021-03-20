import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder} from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent implements OnInit {

registerForm: FormGroup = new FormGroup({});

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      email: '',
      username: '',
      password: '',
      confirmPassword: ''
    });

    this.registerForm.valueChanges.subscribe(console.log);
  }

  onSubmit(): void {
    if(this.registerForm.valid)
    {
      console.log("form submitted!");
      this.registerForm.reset();
    }
  }

}
