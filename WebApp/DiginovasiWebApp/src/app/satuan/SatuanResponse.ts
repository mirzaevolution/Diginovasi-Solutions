import { ObjectDataResponse } from './../ObjectDataResponse';
import { ObjectBaseResponse } from './../ObjectBaseResponse';

export class SatuanObject{
  public id: number;
  public kode: string;
  public deskripsi: string;
}
export class SatuanBaseResponse extends ObjectBaseResponse{

}
export class SatuanDataResponse extends ObjectDataResponse<SatuanObject>{

}
