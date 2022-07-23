import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistDetailesComponent } from './artist-detailes.component';

describe('ArtistDetailesComponent', () => {
  let component: ArtistDetailesComponent;
  let fixture: ComponentFixture<ArtistDetailesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArtistDetailesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ArtistDetailesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
