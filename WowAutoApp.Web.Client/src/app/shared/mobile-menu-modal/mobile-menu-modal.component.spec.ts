import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MobileMenuModalComponent } from './mobile-menu-modal.component';

describe('MobileMenuModalComponent', () => {
  let component: MobileMenuModalComponent;
  let fixture: ComponentFixture<MobileMenuModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MobileMenuModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MobileMenuModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
