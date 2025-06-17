import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomerService } from './customer.service';
import { ProductService } from './product.service';
import { CompletePurchase } from '../Classes/completePurchase';

@Injectable({
  providedIn: 'root'
})
export class CompletePurchaseService {
  private readonly basicUrl: string = 'https://localhost:7076/api/CompletePurchase';

  constructor(public http: HttpClient, public customerService: CustomerService, public productService: ProductService) { }

  // הגדרת אובייקט קנייה
  CompletePurchase: CompletePurchase = new CompletePurchase();

  finish(): Observable<any> {
    const completePurchaseDto: CompletePurchase = {
      currentUser: this.customerService.currentCustomer,
      purchaseAmount: this.productService.AmountPaid,
      note: this.CompletePurchase.note,
      products: this.productService.shoppingCart,
    };
    return this.http.post(`${this.basicUrl}`, completePurchaseDto);
  }
}
