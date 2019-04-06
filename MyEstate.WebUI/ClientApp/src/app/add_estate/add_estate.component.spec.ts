/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Add_estateComponent } from './add_estate.component';

describe('Add_estateComponent', () => {
  let component: Add_estateComponent;
  let fixture: ComponentFixture<Add_estateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Add_estateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Add_estateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
