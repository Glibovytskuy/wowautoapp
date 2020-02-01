import { Component, OnInit } from '@angular/core';
import { CreditAplicationForm } from '@app/core/forms/creditApplications/CreditAplicationForm';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '@app/services/auth.service';
import { JwtToken } from '@app/core/models/JwtToken';
import { OwnerType } from "@app/core/enums/OwnerType";
import { EmploymentStatusType } from "@app/core/enums/EmploymentStatusType";
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-credit-application',
  templateUrl: './credit-application.component.html',
  styleUrls: ['./credit-application.component.css']
})
export class CreditApplicationComponent implements OnInit {

  public form = new CreditAplicationForm().CreditAplicationForm;

  public OwnerTypes: any;
  public EmploymentStatusTypes: any;


  constructor(
    private _authService: AuthService,
    private _toastr: ToastrService,
    private _router: Router,
    private _title: Title
  ) { }
    
  ngOnInit() {
    this._title.setTitle('Credit aplication');
    this.OwnerTypes = OwnerType.values();
    this.EmploymentStatusTypes = EmploymentStatusType.values();
  }

  public register(): void {
    //TODO: Need implement complit form
    this.form.get('SecurityStamp').setValue('dc18fcf2-c24d-4c5d-abda-bbccd60d9c38');
    this.form.get('DriverLicensePhotoId').setValue('');
    this.changeBirthDateFormat();
    
    //ToDo: Need to improve this if ve have not value need set default value but we need see place holder.
    
    if(this.form.get('DownPayment').value == null)
      this.form.get('DownPayment').setValue(0);

    if(this.form.get('TotalAmount').value == null)
      this.form.get('TotalAmount').setValue(0);

    if(this.form.get('HouseFlatNumber').value == null)
      this.form.get('HouseFlatNumber').setValue(0);
    //


    this._authService.register(this.form.value)
      .subscribe(
        (jwt: JwtToken) => {
          if (jwt) {
            this._toastr.success('Register Success');

            this._authService.saveToken(jwt.access_token, jwt.refresh_token);

            this._router.navigate(['/']);
            // this._accountService.initialize(this._globalService._currentUser.ProfileId).subscribe(response =>{
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

  private changeBirthDateFormat() {
    let date = this.form.value.DateOfBirth;
    this.form.value.DateOfBirth = `${(date.getMonth() + 1)}.${date.getDate()}.${date.getFullYear()}`;
  }
}
