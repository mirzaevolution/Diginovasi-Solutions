import { ObjectDataResponse } from './../ObjectDataResponse';
import { ObjectBaseResponse } from './../ObjectBaseResponse';

export class SalesOrderItemObject{
  public id: number;
  public salesOrderId: number;
  public noSalesOrder: string;
  public materialId: number;
  public kodeMaterial: string;
  public deskripsiMaterial: string;
  public jumlah: number;
  public kodeSatuan: string;
  public harga: number;
  public subTotal: number;
}
export class SalesOrderItemBaseResponse extends ObjectBaseResponse{

}
export class SalesOrderItemDataResponse extends ObjectDataResponse<SalesOrderItemObject>{

}
export class SalesOrderItemDataListResponse extends ObjectDataResponse<Array<SalesOrderItemObject>>{

}
