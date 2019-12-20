import { Injectable } from "@angular/core";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Router} from "@angular/router";
import { Observable } from "rxjs/Observable";
import { environment } from "@env/environment";

@Injectable()
export class HttpClientService {
    
    private static readonly BASE: string = environment.baseUrl;
    private static readonly API: string = environment.apiUrl;

    //Controllers
    public static readonly ACCOUNTS_CONTROLLER = HttpClientService.API + "/Accounts";


    constructor(
        private _httpClient: HttpClient,
        private _router: Router,
    ) {}

    public get(url: string,
               params?: any | null): Observable<any> {
        return this._httpClient.get(url, this._getOptions(params));
    }

    public post(url: string,
                body?: any | null,
                params?: any | null,
                isFormData?: boolean | false,
                isNonAuthRequest?: boolean | false): Observable<any> {
        return this._httpClient.post(url, body, this._getOptions(params, isFormData, isNonAuthRequest));
    }

    public put(url: string,
               body?: any | null): Observable<any> {
        return this._httpClient.put(url, body, this._getOptions());
    }

    public delete(url: string,
                  params?: any | null): Observable<any> {
        return this._httpClient.delete(url, this._getOptions(params));
    }

    public getToken() {
        let token;
        token = localStorage.getItem('token');
        if (token === null && (localStorage.getItem('refresh_token') === null))
            this._router.navigate(['/login']);
        return token;
    }

    public getBaseUrl(): string{
        return HttpClientService.BASE;
    }

    private _getOptions(params?,
                        isFormData?,
                        isNonAuthRequest?) {
        let options = {
            headers: this._getAuthHeaders(isFormData, isNonAuthRequest),
            params: params
        };
        return options;
    }

    private _getAuthHeaders(isFormData?: boolean, isNonAuthRequest?: boolean): HttpHeaders {
        let headers = new HttpHeaders();
        headers = headers.append('client_id', 'wowautoapp_spa');

        if (!isNonAuthRequest) {
            let token = 'Bearer ' + this.getToken();
            headers = headers.append('Authorization', token);
        }

        if (!isFormData)
            headers = headers.append('Content-Type', 'application/json');
        
        return headers;
    }
}