import { Component, OnInit } from '@angular/core';
import { JwtToken } from '@app/core/models/JwtToken';
import { AuthService } from '@app/services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(
    private _authService: AuthService,
    private _toastr: ToastrService
  ) { 
  }

  ngOnInit() {
  }
  public register(registerModel: any): void {
    if (registerModel.password !== registerModel.confirmPassword) {
      this._toastr.error('The password and confirmation password do not match', 'Error!');
    }
    else {
      if (registerModel.password === registerModel.confirmPassword) {
        this._authService.register({...registerModel})
          .subscribe(
            (jwt: JwtToken) => {
                if (jwt) {
                  this._authService.saveToken(jwt.access_token, jwt.refresh_token);
                  // this._accountService.initialize(this._globalService._currentUser.ProfileId).subscribe(response =>{
                  //   this._globalService.unreadNotificationCount = response.unreadNotificationCount;
                  //   this._authService.initializeAfterAuthentication(response);
                  // });
                }

            },
            (errorMessage) => {
                let modifiedString = this._authService.prepareModelError(errorMessage.error);
                this._toastr.error(modifiedString);
            });
      }
    }
  }
}