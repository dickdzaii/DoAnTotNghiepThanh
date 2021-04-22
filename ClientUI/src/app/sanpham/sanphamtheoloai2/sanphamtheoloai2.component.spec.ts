import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Sanphamtheoloai2Component } from './sanphamtheoloai2.component';

describe('Sanphamtheoloai2Component', () => {
  let component: Sanphamtheoloai2Component;
  let fixture: ComponentFixture<Sanphamtheoloai2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Sanphamtheoloai2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Sanphamtheoloai2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
