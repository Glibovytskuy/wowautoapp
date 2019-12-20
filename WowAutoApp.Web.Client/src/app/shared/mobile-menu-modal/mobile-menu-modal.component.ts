import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { AuthService } from '@app/services/auth.service';

@Component({
  selector: 'app-mobile-menu-modal',
  templateUrl: './mobile-menu-modal.component.html',
  styleUrls: ['./mobile-menu-modal.component.css']
})
export class MobileMenuModalComponent {

  constructor(private _authService: AuthService) {}

  test() {
    this._authService.onCloseModalMenu$.next();
  }

}
