import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { GlobalService } from '@app/services/general-services/global.service';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '@app/services/auth.service';
import { ProfileService } from '@app/services/profile.service';

@Component({
  selector: 'app-main-profile',
  templateUrl: './main-profile.component.html',
  styleUrls: ['./main-profile.component.css']
})
export class MainProfileComponent implements OnInit {

  constructor(
    private _title: Title,
    public globalService: GlobalService,
    public _authService: AuthService,
    private _toastr: ToastrService,
    private _profileService: ProfileService,
    ) { }

  ngOnInit() {
    this._title.setTitle('Profile');
  }

  public ConfirmEmail(): void {
    this._profileService.sendVerifyEmail()
      .subscribe(
        (response: any) => {
            this._toastr.success('Verification email has been sent.');
        },
        (errorMessage) => {
          this._toastr.success('Unable to send email.');
          for(var index in errorMessage.error) 
          {  
            this._toastr.error(errorMessage.error[index]);   
          } 
        });
  }
}
