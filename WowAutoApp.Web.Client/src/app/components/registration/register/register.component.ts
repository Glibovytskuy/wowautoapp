import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../../../core/general-services/register.service';
import { JwtToken } from '../../../core/models/JwtToken';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(
    private _registerService: RegisterService

    //private _alertService: AlertService
  ) { 
  }

  ngOnInit() {
  }
  public register(registerModel: any): void {
    if (registerModel.password !== registerModel.confirmPassword) {
      //TODO: Need to create alert service  
      //this._alertService.error('The password and confirmation password do not match', 'Error!');
    }
    else {
      if (registerModel.password === registerModel.confirmPassword) {
        this._registerService.register({...registerModel})
          .subscribe(
            (jwt: JwtToken) => {
                if (jwt) {
                  // this._authService.saveToken(jwt.access_token, jwt.refresh_token);
                  // this._accountService.initialize(this._globalService._currentUser.ProfileId).subscribe(response =>{
                  //   this._globalService.unreadNotificationCount = response.unreadNotificationCount;
                  //   this._authService.initializeAfterAuthentication(response);
                  // });
                }

            },

            (errorMessage) => {
                let modifiedString = this._registerService.prepareModelError(errorMessage.error);
                //this._alertService.error(modifiedString);
            });
      }
    }
  }
}