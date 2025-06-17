import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../Classes/Customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  constructor(public cusServer: HttpClient) { }
  currentCustomer: Customer = new Customer()
  newEmail: string = ""

  basicUrl: string = "https://localhost:7076/api/Customer/"
  getC(): Observable<Array<Customer>> {
    return this.cusServer.get<Array<Customer>>(`${this.basicUrl}`)
  }
  sign_up(): Observable<Customer> {
    const customerData = {
      customerName: this.currentCustomer.customerName,
      phone: this.currentCustomer.phone,
      email: this.currentCustomer.email,
      dateOfBirth: this.currentCustomer.dateOfBirth
    };
    return this.cusServer.post<Customer>(this.basicUrl, customerData);
  }
  login(email: string): Observable<Customer> {
    return this.cusServer.get<Customer>(`${this.basicUrl}${email}`)
  }

}
