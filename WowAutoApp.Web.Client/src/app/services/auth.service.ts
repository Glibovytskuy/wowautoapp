import { Injectable } from '@angular/core';
import { Observable } from "rxjs/Observable";
import { HttpClientService } from "@app/services/general-services/http-client.service";
import { Subject } from 'rxjs/Subject';

@Injectable()
export class AuthService {
  onCloseModalMenu$ = new Subject<void>();

  public constructor(private _httpClient: HttpClientService) {}

    public register(model): Observable<any> {
        return this._httpClient.post(HttpClientService.ACCOUNTS_CONTROLLER,
            model, false, true, true);
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
