import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Sanphamtheoloai1Component } from './sanphamtheoloai1.component';

describe('Sanphamtheoloai1Component', () => {
  let component: Sanphamtheoloai1Component;
  let fixture: ComponentFixture<Sanphamtheoloai1Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Sanphamtheoloai1Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Sanphamtheoloai1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
