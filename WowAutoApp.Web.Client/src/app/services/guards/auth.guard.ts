import {Injectable} from '@angular/core';
import {CanActivate, Router} from '@angular/router';
import { AuthService } from '../auth.service';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(
        private router: Router,
        private auth: AuthService
    ) {}

    public canActivate(): boolean {
        if (this.auth.isLogged())
            return true;

        if (localStorage.getItem('token') !== null) {
            this.auth.refreshTokens().subscribe(response => {
                let token = response['access_token'];
                let refreshToken = response['refresh_token'];
                this.auth.saveToken(token, refreshToken);
                location.reload();
            },
            () => {
                this.auth.logout();
                this.router.navigateByUrl('/login');
            });
            return false;
        }

        this.router.navigate(['/login']);
        return false;
    }
}