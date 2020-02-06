import { Component, OnInit } from '@angular/core';
import { CreditAplicationForm } from '@app/core/forms/creditApplications/CreditAplicationForm';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '@app/services/auth.service';
import { JwtToken } from '@app/core/models/JwtToken';
import { OwnerType } from "@app/core/enums/OwnerType";
import { EmploymentStatusType } from "@app/core/enums/EmploymentStatusType";
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { GlobalService } from '@app/services/general-services/global.service';
import { CreditAppService } from '@app/services/credit-app.service';
import { Profile } from '@app/core/models/profile.model';

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
    public _authService: AuthService,
    private _globalService: GlobalService,
    private _creditApplicationService: CreditAppService,
    private _toastr: ToastrService,
    private _router: Router,
    private _title: Title
  ) { }
    
  ngOnInit() {
    this._title.setTitle('Credit aplication');
    this.OwnerTypes = OwnerType.values();
    this.EmploymentStatusTypes = EmploymentStatusType.values();

    if(this._authService.isLogged()){
      this.getprofileData();
    }
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

  public edit(): void {
    //ToDo: Need to improve this if ve have not value need set default value but we need see place holder.
      
    if(this.form.get('DownPayment').value == null)
    this.form.get('DownPayment').setValue(0);

    if(this.form.get('TotalAmount').value == null)
      this.form.get('TotalAmount').setValue(0);

    if(this.form.get('HouseFlatNumber').value == null)
      this.form.get('HouseFlatNumber').setValue(0);
    //

    this._creditApplicationService.edit(this.form.value)
      .subscribe(
        (response: any) => {
            this._toastr.success('Edit Success');
        },
        (errorMessage) => {
          for(var index in errorMessage.error) 
          {  
            this._toastr.error(errorMessage.error[index]);   
          } 
        });
  }

  private changeBirthDateFormat(): void {
    let date = this.form.value.DateOfBirth;
    this.form.value.DateOfBirth = `${(date.getMonth() + 1)}.${date.getDate()}.${date.getFullYear()}`;
  }

  private getprofileData(): void {
    this._creditApplicationService.get().subscribe(
      (response: any) => {
          this.initFormGroup(response);
      },
      (errorMessage) => {
        this.form.get('FirstName').setValue(this._globalService._currentUser.FirstName);
        this.form.get('LastName').setValue(this._globalService._currentUser.LastName);
        this.form.get('Email').setValue(this._globalService._currentUser.Email);
        this.form.get('MobileNumber').setValue(this._globalService._currentUser.PhoneNumber);
        //Just for validator. For edit case not using
        this.form.get('Password').setValue('!templatePass1');
        this.form.get('ConfirmPassword').setValue('!templatePass1');
        
        for(var index in errorMessage.error) 
        {  
          this._toastr.error(errorMessage.error[index]);   
        } 
      });
  }

  private initFormGroup(profileData: any): void {
    this.form.get('FirstName').setValue(this._globalService._currentUser.FirstName);
    this.form.get('LastName').setValue(this._globalService._currentUser.LastName);
    this.form.get('Email').setValue(this._globalService._currentUser.Email);
    this.form.get('MobileNumber').setValue(this._globalService._currentUser.PhoneNumber);

    //Profile Part
    this.form.get('SocialSecurityNumber').setValue(profileData.socialSecurityNumber);
    this.form.get('DateOfBirth').setValue((new Date(profileData.dateOfBirth)).toLocaleDateString('en-US'));
    this.form.get('PhoneNumber').setValue(profileData.phoneNumber);
    this.form.get('StreetAddress').setValue(profileData.streetAddress);
    this.form.get('City').setValue(profileData.city);
    this.form.get('State').setValue(profileData.state);
    this.form.get('ZipCode').setValue(profileData.zipCode);
    this.form.get('ResidenceOwner').setValue(profileData.residenceOwner); //ToDo: Need to get int value from name
    this.form.get('MonthlyRent').setValue(profileData.monthlyRent);
    this.form.get('MobileNumber').setValue(profileData.mobileNumber);
    this.form.get('HouseFlatNumber').setValue(profileData.houseFlatNumber);
    this.form.get('EmploymentStatus').setValue(profileData.employmentStatus); //ToDo: Need to get int value from name

    //Vehicle Part
    this.form.get('VehicleName').setValue(profileData.vehicleName);
    this.form.get('DownPayment').setValue(profileData.sownPayment);
    this.form.get('TotalAmount').setValue(profileData.totalAmount);
    this.form.get('OtherInfo').setValue(profileData.otherInfo);
    this.form.get('DriverLicensePhotoId').setValue(profileData.driverLicensePhotoId);



    //Just for validator. For edit case not using
    this.form.get('Password').setValue('!templatePass1');
    this.form.get('ConfirmPassword').setValue('!templatePass1');
  }
}