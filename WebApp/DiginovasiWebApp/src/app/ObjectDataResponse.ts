import { ObjectBaseResponse } from './ObjectBaseResponse';
export class ObjectDataResponse<T> extends ObjectBaseResponse{
  public data: T;
}
