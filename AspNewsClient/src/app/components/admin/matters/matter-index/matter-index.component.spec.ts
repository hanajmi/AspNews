import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MatterIndexComponent } from './matter-index.component';

describe('MatterIndexComponent', () => {
  let component: MatterIndexComponent;
  let fixture: ComponentFixture<MatterIndexComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MatterIndexComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MatterIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
