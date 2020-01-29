import { Component, TemplateRef, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  modalRef: BsModalRef;
  config = {
    class: "menu-modal"
  };
  
  constructor(
    private modalService: BsModalService,
    public auth: AuthService
  ) {}

  ngOnInit() {
    this._onCloseModalMenuSub();
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, this.config);
  }

  private _onCloseModalMenuSub() {
    this.auth.onCloseModalMenu$.subscribe(() => this.modalRef.hide());
  }

}
