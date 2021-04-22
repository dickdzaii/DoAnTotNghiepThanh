import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DangnhapdangkyComponent } from './dangnhapdangky.component';

describe('DangnhapdangkyComponent', () => {
  let component: DangnhapdangkyComponent;
  let fixture: ComponentFixture<DangnhapdangkyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DangnhapdangkyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DangnhapdangkyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
