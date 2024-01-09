import { Component, OnInit } from '@angular/core';
import { Observable, Subscription, of } from 'rxjs';
import { ProductType } from 'src/app/enums/productType';
import { City } from 'src/app/interfaces/city';
import { FilterData } from 'src/app/interfaces/filterData';
import { Product } from 'src/app/interfaces/product';
import { CitiesService } from 'src/app/services/cities/cities.service';
import { ProductsService } from 'src/app/services/products/products.service';


const INITIAL_FILTER_DATA: FilterData = { pageNumber: 1, pageSize: 5 };

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
})
export class ProductsComponent implements OnInit {
  products$: Observable<Product[]> = of();
  cities: { [id: number]: string } = {};

  ProductTypeE = ProductType;
  ProductTypeNames = {};

  subscriptions = new Subscription(); 



  filterData: FilterData = {...INITIAL_FILTER_DATA};
  prevFilterData: FilterData = {...INITIAL_FILTER_DATA};

  filterSize: number = 0;

  constructor(
    private productsService: ProductsService,
    private citiesService: CitiesService
  ) {}

  ngOnInit(): void {
    const sub = this.citiesService.getCities().subscribe((cities: City[]) => {
      cities.map((p) => {
        this.cities[p.id] = p.name;
      });
      this.productsService.getProductsFilterSize(INITIAL_FILTER_DATA).subscribe(c => {
        this.filterSize = c;
      })
      this.products$ = this.productsService.getProductsFiltered(INITIAL_FILTER_DATA);
      sub.unsubscribe();
    });
    this.ProductTypeNames = Object.values(ProductType).filter((f) =>
      isNaN(Number(f))
    );
  }

  clearFilter(): void {
    this.filterData = {...INITIAL_FILTER_DATA};
    this.searchFilter();
  }

  searchFilter(): void {
    this.prevFilterData = {...this.filterData};
    const sub = this.productsService.getProductsFilterSize(this.filterData).subscribe(c => {
      this.filterSize = c;
      sub.unsubscribe();
    });
    this.products$ = this.productsService.getProductsFiltered(this.filterData);
  }

  nextData(): void {
    this.filterData = {...this.filterData, pageNumber: this.filterData.pageNumber + 1}
    this.searchFilter();
  }

  prevData(): void {
    this.filterData = {...this.filterData, pageNumber: this.filterData.pageNumber - 1}
    this.searchFilter();
  }

  resetButtons() {
    this.filterData = {...this.filterData, pageNumber: 1};
    this.searchFilter();
  }
}
