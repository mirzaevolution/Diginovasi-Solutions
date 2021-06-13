import { ObjectDataResponse } from './../ObjectDataResponse';
import { ObjectBaseResponse } from './../ObjectBaseResponse';

export class MaterialObject{
  public id: number;
  public kode: string;
  public deskripsi: string;
  public satuanId: number;
  public harga: number;
  public urlGambar: string;
  public formattedUrlGambar: string;
}
export class MaterialBaseResponse extends ObjectBaseResponse { }
export class MaterialDataResponse extends ObjectDataResponse<MaterialObject> { }
export class MaterialDataListResponse extends ObjectDataResponse<Array<MaterialObject>> { }

