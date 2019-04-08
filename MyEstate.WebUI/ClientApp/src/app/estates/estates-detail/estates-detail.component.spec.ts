import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EstatesDetailComponent } from './estates-detail.component';

describe('EstatesDetailComponent', () => {
  let component: EstatesDetailComponent;
  let fixture: ComponentFixture<EstatesDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EstatesDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EstatesDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
