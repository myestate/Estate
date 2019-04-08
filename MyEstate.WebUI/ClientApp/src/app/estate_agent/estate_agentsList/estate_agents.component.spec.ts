/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Estate_agentsComponent } from './estate_agents.component';

describe('Estate_agentsComponent', () => {
  let component: Estate_agentsComponent;
  let fixture: ComponentFixture<Estate_agentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Estate_agentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Estate_agentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
