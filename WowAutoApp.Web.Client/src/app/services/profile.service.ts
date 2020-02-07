import { Injectable } from '@angular/core';
import { HttpClientService } from './general-services/http-client.service';
import { Observable } from 'rxjs';
import { environment } from '@env/environment';

@Injectable()
export class ProfileService {

  constructor(
    private _httpClient: HttpClientService
  ) { }

  public sendVerifyEmail(): Observable<any> {
    let params = {
      callbackUrl: environment.clientUrl
    }
    return this._httpClient.get(HttpClientService.ACCOUNT_SEND_CONFIRMATION_EMAIL, params)
      .map((response: any) => response);
  }
}
