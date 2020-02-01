import { Component, OnInit } from '@angular/core';
import { VehicleForm } from '@app/core/forms/admin/VehicleForm';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-add-vehicle',
  templateUrl: './add-vehicle.component.html',
  styleUrls: ['./add-vehicle.component.css']
})
export class AddVehicleComponent implements OnInit {
  public year = new Date().getFullYear();
  public years: any[];

  public form = new VehicleForm().VehicleForm;

  constructor(private _title: Title) { }

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
