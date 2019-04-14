/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from 'src/app/registerAsAgent/node_modules/@angular/core/testing';
import { By } from 'src/app/registerAsAgent/node_modules/@angular/platform-browser';
import { DebugElement } from 'src/app/registerAsAgent/node_modules/@angular/core';

import { RegisterAsAgentComponent } from './registerAsAgent.component';

describe('RegisterAsAgentComponent', () => {
  let component: RegisterAsAgentComponent;
  let fixture: ComponentFixture<RegisterAsAgentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterAsAgentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterAsAgentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
