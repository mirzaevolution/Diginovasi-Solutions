import { ObjectDataResponse } from './../ObjectDataResponse';
import { ObjectBaseResponse } from './../ObjectBaseResponse';
export class TanggalStruct{
  public year: number;
  public month: number;
  public day: number;
}
export class SalesOrderObject{
  public id: number;
  public noSalesOrder: string;
  public customerId: number;
  public noCustomer: string;
  public namaCustomer: string;
  public total: number;
  public tanggal: string;
  public tanggalStruct: TanggalStruct;
}
export class SalesOrderBaseResponse extends ObjectBaseResponse{

}
export class SalesOrderDataResponse extends ObjectDataResponse<SalesOrderObject>{

}
export class SalesOrderDataListResponse extends ObjectDataResponse<Array<SalesOrderObject>>{

}
