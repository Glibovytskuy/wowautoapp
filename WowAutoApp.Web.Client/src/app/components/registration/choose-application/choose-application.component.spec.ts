import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChooseApplicationComponent } from './choose-application.component';

describe('ChooseApplicationComponent', () => {
  let component: ChooseApplicationComponent;
  let fixture: ComponentFixture<ChooseApplicationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChooseApplicationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChooseApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
