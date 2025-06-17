import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../Classes/Product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  itemCount: number = 0
  AmountPaid: number = 0;
  constructor(public proServer: HttpClient) { }
  shoppingCart: Product[] = [];
  dictionary: Array<{ categoryName: string, products: Product[] }> = [];
  basicUrl: string = "https://localhost:7076/api/Product/"
  getP(): Observable<Array<Product>> {
    return this.proServer.get<Array<Product>>(`${this.basicUrl}`)
  }
  productByCategoryCode(categoryCode: number): Observable<Array<Product>> {
    return this.proServer.get<Array<Product>>(`${this.basicUrl}${categoryCode}`)
  }
  productByPrice(categoryCode: number, min?: number, max?: number): Observable<Array<Product>> {
    let params = new HttpParams();
    params = params.append("categoryCode", categoryCode.toString()); 
    if (min !== undefined) {
      params = params.append('min', min.toString());
    }
    if (max !== undefined) {
      params = params.append('max', max.toString());
    }
    return this.proServer.get<Array<Product>>(`${this.basicUrl}price`, { params });
  }

}
