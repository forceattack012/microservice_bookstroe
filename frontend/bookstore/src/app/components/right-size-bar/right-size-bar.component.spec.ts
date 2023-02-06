import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RightSizeBarComponent } from './right-size-bar.component';

describe('RightSizeBarComponent', () => {
  let component: RightSizeBarComponent;
  let fixture: ComponentFixture<RightSizeBarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RightSizeBarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RightSizeBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
