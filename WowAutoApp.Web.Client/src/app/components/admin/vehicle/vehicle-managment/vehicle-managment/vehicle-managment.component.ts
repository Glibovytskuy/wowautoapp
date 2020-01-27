import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-vehicle-managment',
  templateUrl: './vehicle-managment.component.html',
  styleUrls: ['./vehicle-managment.component.css']
})
export class VehicleManagmentComponent implements OnInit {

  constructor(
    private _title: Title
  ) { }

  ngOnInit() {
    this._title.setTitle('Vehicle managment');
  }

}
