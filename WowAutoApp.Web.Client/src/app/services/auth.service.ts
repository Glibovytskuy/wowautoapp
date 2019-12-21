import { Injectable } from '@angular/core';
import { Observable } from "rxjs/Observable";
import { HttpClientService } from "@app/services/general-services/http-client.service";
import { Subject } from 'rxjs/Subject';
import { HttpParams } from '@angular/common/http';
import { JwtToken } from '@app/core/models/JwtToken';

@Injectable()
export class AuthService {
  onCloseModalMenu$ = new Subject<void>();

  public constructor(private _httpClient: HttpClientService) {}

    public register(model): Observable<any> {
        return this._httpClient.post(HttpClientService.ACCOUNTS_CONTROLLER,
            model);
    }

    // TODO: Add model classes, use typings!!!
    public login(credentials): Observable<JwtToken> {
        let formData = new HttpParams()
            .append("username", credentials.userName)
            .append("password", credentials.password)
            .append("client_id", "wowautoapp_spa")
            .append("grant_type", "password")
            .append("scope", "openid offline_access email phone profile wowautoapp_api");

        return this._httpClient.post(HttpClientService.IDENTITY_SERVER_CONNECT, formData, null, true, true);
    }

    public prepareModelError(errorObject: any): string{
        let string = "";
        if(errorObject.PasswordRequiresLower){
            errorObject.PasswordRequiresLower.forEach(value => {
                string += value + "<br>";
            });
        }
        if(errorObject.PasswordRequiresNonAlphanumeric){
            errorObject.PasswordRequiresNonAlphanumeric.forEach(value => {
                string += value + "<br>";
            });
        }
        if(errorObject.PasswordRequiresUpper){
            errorObject.PasswordRequiresUpper.forEach(value => {
                string += value + "<br>";
            });
        }
        if(errorObject.PasswordRequiresDigit){
            errorObject.PasswordRequiresDigit.forEach(value => {
                string += value + "<br>";
            });
        }
        if(errorObject.DuplicateUserName){
            errorObject.DuplicateUserName.forEach(value => {
                string += value + "<br>";
            });
        }
        return string;
    }

}
