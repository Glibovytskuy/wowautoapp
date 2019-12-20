import { Injectable } from "@angular/core";
import { HttpClientService } from "./http-client.service";
import { Observable } from "rxjs/Observable";
import { JwtToken } from "../models/JwtToken";
import { environment } from "../../../environments/environment";

@Injectable()
export class RegisterService {

    public constructor(private _httpClient: HttpClientService) {}

    public register(model): Observable<any> {
        return this._httpClient.post(HttpClientService.ACCOUNTS_CONTROLLER,
            model);
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