import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpcungloaiComponent } from './spcungloai.component';

describe('SpcungloaiComponent', () => {
  let component: SpcungloaiComponent;
  let fixture: ComponentFixture<SpcungloaiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpcungloaiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpcungloaiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
