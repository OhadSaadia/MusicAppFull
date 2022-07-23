import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VideosBannersComponent } from './videos-banners.component';

describe('VideosBannersComponent', () => {
  let component: VideosBannersComponent;
  let fixture: ComponentFixture<VideosBannersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VideosBannersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VideosBannersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
