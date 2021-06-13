import { ObjectBaseResponse } from "../ObjectBaseResponse";
import { ObjectDataResponse } from "../ObjectDataResponse";

export class CustomerObject{
  public id: number;
  public noCustomer: string;
  public nama: string;
  public noKontak: string;
}
export class CustomerBaseResponse extends ObjectBaseResponse { }
export class CustomerDataResponse extends ObjectDataResponse<CustomerObject> { }
export class CustomerDataListResponse extends ObjectDataResponse<Array<CustomerObject>> { }

