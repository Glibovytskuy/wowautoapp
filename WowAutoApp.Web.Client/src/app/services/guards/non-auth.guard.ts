import {Injectable} from '@angular/core';
import {CanActivate, Router} from '@angular/router';
import { AuthService } from '../auth.service';

@Injectable()
export class NonAuthGuard implements CanActivate {

    constructor(
        private router: Router,
        private auth: AuthService
    ) {}

    public canActivate(): boolean {
        if (!this.auth.isLogged())
            return true;

        this.router.navigate(['/']);
        return false;
    }
}