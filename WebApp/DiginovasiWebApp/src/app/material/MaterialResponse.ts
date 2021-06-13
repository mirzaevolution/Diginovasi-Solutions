import { ObjectDataResponse } from './../ObjectDataResponse';
import { ObjectBaseResponse } from './../ObjectBaseResponse';

export class MaterialObject{
  public id: number;
  public kode: string;
  public deskripsi: string;
  public satuanId: number;
  public harga: number;
  public urlGamber: string;
}
export class MaterialBaseResponse extends ObjectBaseResponse { }
export class MaterialDataResponse extends ObjectDataResponse<MaterialObject> { }
