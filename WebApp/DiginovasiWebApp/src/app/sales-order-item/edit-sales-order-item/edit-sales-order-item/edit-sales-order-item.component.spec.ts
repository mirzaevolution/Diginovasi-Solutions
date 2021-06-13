import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditSalesOrderItemComponent } from './edit-sales-order-item.component';

describe('EditSalesOrderItemComponent', () => {
  let component: EditSalesOrderItemComponent;
  let fixture: ComponentFixture<EditSalesOrderItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditSalesOrderItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditSalesOrderItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
