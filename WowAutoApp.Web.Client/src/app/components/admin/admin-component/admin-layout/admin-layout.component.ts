import { Component, OnInit } from '@angular/core';
import { GlobalService } from '@app/services/general-services/global.service';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.css']
})
export class AdminLayoutComponent implements OnInit {

  constructor(
    public globalService: GlobalService
  ) { }

  ngOnInit() {}
}