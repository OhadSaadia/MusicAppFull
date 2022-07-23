import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeMenuPageComponent } from './home-menu-page.component';

describe('HomeMenuPageComponent', () => {
  let component: HomeMenuPageComponent;
  let fixture: ComponentFixture<HomeMenuPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeMenuPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeMenuPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
