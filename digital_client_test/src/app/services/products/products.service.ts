import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FilterData } from 'src/app/interfaces/filterData';
import { Product } from 'src/app/interfaces/product';

const BASE_URL = 'http://localhost:5128/api/Products';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  constructor(private http: HttpClient) {}

  getFilterUri(filterData: FilterData) {
    const fromDateStr = filterData.fromDate
      ? '' +
        filterData.fromDate.getFullYear() +
        '-' +
        ('' + (filterData.fromDate.getMonth() + 1)).padStart(2, '0') +
        '-' +
        ('' + filterData.fromDate.getDate()).padStart(2, '0')
      : '';
    const toDateStr = filterData.toDate
      ? '' +
        filterData.toDate.getFullYear() +
        '-' +
        ('' + (filterData.toDate.getMonth() + 1)).padStart(2, '0') +
        '-' +
        ('' + filterData.toDate.getDate()).padStart(2, '0')
      : '';
    let filterUri: string =
      `?PageNumber=${filterData.pageNumber}&PageSize=${filterData.pageSize}` +
      (filterData.nameLike ? `&NameLike=${filterData.nameLike}` : '') +
      (filterData.fromDate ? `&FromDate=${fromDateStr}` : '') +
      (filterData.toDate ? `&ToDate=${toDateStr}` : '') +
      (filterData.productType ? `&ProductType=${filterData.productType}` : '') +
      (filterData.cities
        ? filterData.cities.reduce((prev, city) => prev + `&Cities=${city}`, '')
        : '');

    return filterUri;
  }

  getProductsFilterSize(filterData: FilterData): Observable<number> {
    const filterUri = this.getFilterUri(filterData);
    return this.http.get<number>(`${BASE_URL}/filterSize${filterUri}`);
  }

  getProductsFiltered(filterData: FilterData): Observable<Product[]> {
    const filterUri = this.getFilterUri(filterData);
    return this.http.get<Product[]>(`${BASE_URL}/filter${filterUri}`);
  }
}
