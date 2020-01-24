import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '@app/services/auth.service';
import { JwtToken } from '@app/core/models/JwtToken';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  public form = new FormGroup({
    userName: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(32),
    ])
  });

  isLoading = false;

  constructor(
    private _authService: AuthService,
    private _toastr: ToastrService,
    private _router: Router
      ) {  }


  ngOnInit() {
  }

  public signIn(): void {
    this._authService.login(this.form.value)
      .subscribe(
          (jwt: JwtToken) => {
            this._toastr.success('Login Success');

            this._authService.saveToken(jwt.access_token, jwt.refresh_token);

            this._router.navigate(['/profile']);
            //ToDo: Need to implement init service
            // this._accountService.initialize(this._globalService._currentUser.ProfileId).subscribe(response =>{
            //   this._authService.initializeAfterAuthentication(response);
            // });
          },
          (errorMessage) => {
            let message = "";
            if(errorMessage.error.error_description === "invalid_username_or_password"){
                message = "Invalid username or password.";
            }
            else{
                message = "Something went wrong. Please contact administrator";
            }
            this._toastr.error(message);
          });
  }

  facebookLogin(){
    
  }

  googleLogin(){
    
  }
}
