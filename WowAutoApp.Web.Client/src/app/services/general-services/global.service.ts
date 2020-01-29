import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Role } from "@app/core/enums/Role";
import { CurrentUser } from "@app/components/user/CurrentUser";
import {JwtHelper} from "angular2-jwt";

@Injectable()
export class GlobalService {
    private _jwt = new JwtHelper();

    public _currentUser: CurrentUser;
    public _profileId: number;
    public _avatarUrl: string;
    public _roles: any[];

    public constructor(private _router: Router){
       this.getDataFromToken();
    }

    public getDataFromToken(): void {
        let token = localStorage.getItem('token');
        if (token) {
            const decodedToken = this.decode(token);

            if (!this._currentUser) {
                this.prepareDataFromToken(decodedToken);
            } else {
                if (this._currentUser.Id === decodedToken.Id && this._currentUser.Email === decodedToken.Email) {
                    this.prepareDataFromToken(decodedToken);
                } else {
                    localStorage.clear();
                    this._router.navigate(['/login']);
                }
            }
        }
    }

    private prepareDataFromToken(decodedToken) {
        this._currentUser = decodedToken;
        this._profileId = this._currentUser.ProfileId;
        this._avatarUrl = this._currentUser.AvatarUrl;
        this._roles = this._currentUser.Roles;
    }

    public hasRole(role: Role): boolean {
        if(this._currentUser && this._currentUser.Roles)
            return this._currentUser.Roles.includes(role.toString())

            return false;
    }

    private decode(token: string): CurrentUser {
        let decoded = this._jwt.decodeToken(token);

        let id = decoded['sub'];
        let username = decoded['name'];
        let user = new CurrentUser(id, username);

        user.Email = decoded['email'];
        user.FirstName = decoded['firstName'];
        user.LastName = decoded['lastName'];
        user.PhoneNumber = decoded['phoneNumber'];
        user.IsEmailVerified = decoded['isEmailVerified'] == 'True';
        user.AvatarUrl = decoded['avatarUrl'];
        user.Roles = decoded['role'];
        user.ProfileId = decoded['profileId'];

        return user;
    }
}