import { ProductType } from '../enums/productType';

export interface Product {
  id: number;
  productType: ProductType;
  name: string;
  price: number;
  createdDate: Date;
  manufacturerCityId: number;
}