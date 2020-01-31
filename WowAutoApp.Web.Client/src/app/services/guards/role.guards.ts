import { Injectable } from "@angular/core";
import { Router, ActivatedRouteSnapshot, CanActivate } from "@angular/router";
import { GlobalService } from "../general-services/global.service";

@Injectable()
export class RoleGuard implements CanActivate {
    constructor(
        private _router: Router,
        private _globalService: GlobalService){
        }

    public canActivate(route: ActivatedRouteSnapshot): boolean{
        let havePermission = this._globalService.hasRole(route.data["roles"]);

        if(havePermission)
            return true;

        this._router.navigate(['/']);
        return false;
    }
}