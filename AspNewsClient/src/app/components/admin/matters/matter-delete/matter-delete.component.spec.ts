import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MatterDeleteComponent } from './matter-delete.component';

describe('MatterDeleteComponent', () => {
  let component: MatterDeleteComponent;
  let fixture: ComponentFixture<MatterDeleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MatterDeleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MatterDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
