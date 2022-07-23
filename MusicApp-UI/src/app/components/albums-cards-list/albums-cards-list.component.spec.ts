import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlbumsCardsListComponent } from './albums-cards-list.component';

describe('AlbumsCardsListComponent', () => {
  let component: AlbumsCardsListComponent;
  let fixture: ComponentFixture<AlbumsCardsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlbumsCardsListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AlbumsCardsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
