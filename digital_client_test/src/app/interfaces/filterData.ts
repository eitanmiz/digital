import { ProductType } from '../enums/productType';
import { City } from './city';

export interface FilterData {
  nameLike?: string;
  fromDate?: Date;
  toDate?: Date;
  productType?: ProductType;
  cities?: number[];
  pageNumber: number;
  pageSize: number;
}