import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-choose-application',
  templateUrl: './choose-application.component.html',
  styleUrls: ['./choose-application.component.css']
})
export class ChooseApplicationComponent implements OnInit {

  constructor(
    private _title: Title
  ) { }
  
  ngOnInit() {
  this._title.setTitle('Select application');
  }

}
