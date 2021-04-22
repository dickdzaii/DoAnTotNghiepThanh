import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CtdonhangComponent } from './ctdonhang.component';

describe('CtdonhangComponent', () => {
  let component: CtdonhangComponent;
  let fixture: ComponentFixture<CtdonhangComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CtdonhangComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CtdonhangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
