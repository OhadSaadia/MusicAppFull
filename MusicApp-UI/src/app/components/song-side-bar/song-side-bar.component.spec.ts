import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SongSideBarComponent } from './song-side-bar.component';

describe('SongSideBarComponent', () => {
  let component: SongSideBarComponent;
  let fixture: ComponentFixture<SongSideBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SongSideBarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SongSideBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
