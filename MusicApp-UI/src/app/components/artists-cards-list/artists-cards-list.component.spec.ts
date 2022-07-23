import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistsCardsListComponent } from './artists-cards-list.component';

describe('ArtistsCardsListComponent', () => {
  let component: ArtistsCardsListComponent;
  let fixture: ComponentFixture<ArtistsCardsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArtistsCardsListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ArtistsCardsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
