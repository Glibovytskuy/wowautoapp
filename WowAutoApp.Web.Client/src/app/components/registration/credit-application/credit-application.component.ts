import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../../../core/general-services/register.service';
import { JwtToken } from '../../../core/models/JwtToken';
import { CreditAplicationForm } from '@app/core/forms/creditApplications/CreditAplicationForm';

@Component({
  selector: 'app-credit-application',
  templateUrl: './credit-application.component.html',
  styleUrls: ['./credit-application.component.css']
})
export class CreditApplicationComponent implements OnInit {

  public form = new CreditAplicationForm().CreditAplicationForm;

  constructor(
    private _registerService: RegisterService

  ) { }

  ngOnInit() {
  }

  public register(): void {
    //TODO: Need implement complit form
    this.form.get('SecurityStamp').setValue('dc18fcf2-c24d-4c5d-abda-bbccd60d9c38');
    this.form.get('CallbackUrl').setValue('http://localhost:52098');
    this.form.get('IsEmailVerified').setValue('false');
    this.form.get('DriverLicensePhotoId').setValue('');

    this._registerService.register(this.form.value)
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
