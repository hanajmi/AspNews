import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MatterShowComponent } from './matter-show.component';

describe('MatterShowComponent', () => {
  let component: MatterShowComponent;
  let fixture: ComponentFixture<MatterShowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MatterShowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MatterShowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
