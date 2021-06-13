import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSalesOrderItemComponent } from './add-sales-order-item.component';

describe('AddSalesOrderItemComponent', () => {
  let component: AddSalesOrderItemComponent;
  let fixture: ComponentFixture<AddSalesOrderItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddSalesOrderItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddSalesOrderItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
