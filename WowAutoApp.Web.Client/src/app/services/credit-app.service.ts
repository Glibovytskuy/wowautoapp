import { Injectable } from '@angular/core';
import { HttpClientService } from './general-services/http-client.service';
import { Observable } from 'rxjs';

@Injectable()
export class CreditAppService {

  constructor(
    private _httpClient: HttpClientService
  ) { }

  public edit(model): Observable<any> {
    return this._httpClient.post(HttpClientService.CREDIT_APPLICATION_CONTROLLER, 
        model, null, false, false);
  }
}
