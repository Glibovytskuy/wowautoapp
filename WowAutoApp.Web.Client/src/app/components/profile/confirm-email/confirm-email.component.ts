import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { GlobalService } from '@app/services/general-services/global.service';
import { ActivatedRoute } from '@angular/router';
import { ProfileService } from '@app/services/profile.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-confirm-email',
  templateUrl: './confirm-email.component.html',
  styleUrls: ['./confirm-email.component.css']
})
export class ConfirmEmailComponent implements OnInit {
  private _email: string;
  private _token: string;
  public message: string;
  public successVerification: boolean;
  
  public constructor(
    private _title: Title,
    public globalService: GlobalService,
    private _route: ActivatedRoute,
    private _profileService: ProfileService,
    private _toastr: ToastrService) 
      {
      this._route.queryParams.subscribe(params => {
          this._email = params['email'];
          this._token = params['token'];
      });
  }

  public ngOnInit(): void {
      this._title.setTitle('Confirm password');
      
      this._profileService.verifyEmail(this._token)
          .subscribe((response) => {
            this._toastr.success('Your email ' + this._email + ' has been successfully verified.');
            this.successVerification = true;
            this.globalService._currentUser.IsEmailVerified = true;
          },
          (error) => {
            this._toastr.success('Your email ' + this._email + ' has not been verified.');
            this.successVerification = false;
            this.globalService._currentUser.IsEmailVerified = false;
          });
  }
}