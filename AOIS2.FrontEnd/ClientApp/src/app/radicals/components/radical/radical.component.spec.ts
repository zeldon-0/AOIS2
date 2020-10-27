import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RadicalComponent } from './radical.component';

describe('RadicalComponent', () => {
  let component: RadicalComponent;
  let fixture: ComponentFixture<RadicalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RadicalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RadicalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
