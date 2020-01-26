import { Component, OnInit } from '@angular/core';
import { JwtToken } from '@app/core/models/JwtToken';
import { AuthService } from '@app/services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { ShortRegisterForm } from '@app/core/forms/register/ShortRegisterForm';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public shortRegisterForm = new ShortRegisterForm().ShortRegisterForm;

  constructor(
    private _authService: AuthService,
    private _toastr: ToastrService,
    private _router: Router,
    private _title: Title
  ) { 
  }

  ngOnInit() {
    this._title.setTitle('Registration');
  }
  

  public register(): void {
    //TODO: Need implement complit form
    this.shortRegisterForm.get('SecurityStamp').setValue('dc18fcf2-c24d-4c5d-abda-bbccd60d9c38');
    this.shortRegisterForm.get('CallbackUrl').setValue('https://wowauto.azurewebsites.net/');

    this._authService.shortRegister(this.shortRegisterForm.value)
      .subscribe(
        (jwt: JwtToken) => {
          if (jwt) {
            this._toastr.success('Register Success');

            this._authService.saveToken(jwt.access_token, jwt.refresh_token);

            this._router.navigate(['/profile']);
            // this._accountService.initialize(this._globalService._currentUser.ProfileId).subscribe(response =>{
            //   this._globalService.unreadNotificationCount = response.unreadNotificationCount;
            //   this._authService.initializeAfterAuthentication(response);
            // });
          }
        },
        (errorMessage) => {
          for(var index in errorMessage.error) 
          {  
            this._toastr.error(errorMessage.error[index]);   
          } 
        });
  }
}