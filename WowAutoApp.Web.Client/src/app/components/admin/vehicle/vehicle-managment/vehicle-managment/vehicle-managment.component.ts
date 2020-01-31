import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { VehicleForm } from '@app/core/forms/admin/VehicleForm';

@Component({
  selector: 'app-vehicle-managment',
  templateUrl: './vehicle-managment.component.html',
  styleUrls: ['./vehicle-managment.component.css']
})
export class VehicleManagmentComponent implements OnInit {

  public year = new Date().getFullYear();
  public years: any[];

  public form = new VehicleForm().VehicleForm;

  constructor(
    private _title: Title
  ) { }

  ngOnInit() {
    this._title.setTitle('Vehicle managment');

    this.setYears();
  }

  private add(vehicleData): void{
    console.warn('Your order has been submitted', vehicleData);

    this.form.reset();
  }

  private setYears(): void{
    var range = [];
    range.push(this.year);
    for (var i = 1; i < 100; i++) {
        range.push(this.year - i);
    }

    this.years = range;
  }
}
