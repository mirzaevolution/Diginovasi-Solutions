import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditSatuanComponent } from './edit-satuan.component';

describe('EditSatuanComponent', () => {
  let component: EditSatuanComponent;
  let fixture: ComponentFixture<EditSatuanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditSatuanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditSatuanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
