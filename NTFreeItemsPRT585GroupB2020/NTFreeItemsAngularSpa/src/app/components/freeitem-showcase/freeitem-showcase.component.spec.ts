import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FreeitemShowcaseComponent } from './freeitem-showcase.component';

describe('FreeitemShowcaseComponent', () => {
  let component: FreeitemShowcaseComponent;
  let fixture: ComponentFixture<FreeitemShowcaseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FreeitemShowcaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FreeitemShowcaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
