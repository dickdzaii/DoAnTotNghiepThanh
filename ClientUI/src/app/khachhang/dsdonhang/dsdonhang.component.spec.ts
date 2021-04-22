import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DsdonhangComponent } from './dsdonhang.component';

describe('DsdonhangComponent', () => {
  let component: DsdonhangComponent;
  let fixture: ComponentFixture<DsdonhangComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DsdonhangComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DsdonhangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
