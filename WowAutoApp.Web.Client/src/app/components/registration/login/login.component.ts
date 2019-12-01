import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  form = new FormGroup({
    userName: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(32),
    ])
  });

  isLoading = false;

  constructor(
      ) {
  }


  ngOnInit() {
  }

  facebookLogin(){
    
  }

  googleLogin(){
    
  }
}