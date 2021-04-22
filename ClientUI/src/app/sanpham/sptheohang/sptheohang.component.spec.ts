import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SptheohangComponent } from './sptheohang.component';

describe('SptheohangComponent', () => {
  let component: SptheohangComponent;
  let fixture: ComponentFixture<SptheohangComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SptheohangComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SptheohangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
