import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { GlobalService } from '@app/services/general-services/global.service';

@Component({
  selector: 'app-main-profile',
  templateUrl: './main-profile.component.html',
  styleUrls: ['./main-profile.component.css']
})
export class MainProfileComponent implements OnInit {

  constructor(private _title: Title,
    public globalService: GlobalService) { }

  ngOnInit() {
    this._title.setTitle('Profile');
  }

}
