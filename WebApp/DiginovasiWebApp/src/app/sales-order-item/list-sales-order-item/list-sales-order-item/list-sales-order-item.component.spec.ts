import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListSalesOrderItemComponent } from './list-sales-order-item.component';

describe('ListSalesOrderItemComponent', () => {
  let component: ListSalesOrderItemComponent;
  let fixture: ComponentFixture<ListSalesOrderItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListSalesOrderItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListSalesOrderItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
