/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Daily_rentComponent } from './daily_rent.component';

describe('Daily_rentComponent', () => {
  let component: Daily_rentComponent;
  let fixture: ComponentFixture<Daily_rentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Daily_rentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Daily_rentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
