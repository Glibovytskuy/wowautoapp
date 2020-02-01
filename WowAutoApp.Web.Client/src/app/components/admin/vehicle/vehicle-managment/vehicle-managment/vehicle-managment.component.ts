import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-vehicle-managment',
  templateUrl: './vehicle-managment.component.html',
  styleUrls: ['./vehicle-managment.component.css']
})
export class VehicleManagmentComponent implements OnInit {

  public vehicleViewModel: any[] = []; // ToDo: need to implement VehicleViewModel 
  // public vehicleViewModel: VehicleViewModel[] = [];

  constructor(
    private _title: Title
  ) { }

  ngOnInit() {
    this._title.setTitle('Vehicle list');

    this.vehicleViewModel.unshift("item 1");
    this.vehicleViewModel.unshift("item 2");
  }
}