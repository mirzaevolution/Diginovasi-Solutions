import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListSatuanComponent } from './list-satuan.component';

describe('ListSatuanComponent', () => {
  let component: ListSatuanComponent;
  let fixture: ComponentFixture<ListSatuanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListSatuanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListSatuanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
