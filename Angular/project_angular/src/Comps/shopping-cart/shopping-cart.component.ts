import { Component } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../Classes/Product';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomerService } from '../../Services/customer.service';
import { CompletePurchaseService } from '../../Services/complete-purchase.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-shopping-cart',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./bootstrap.min.css', './shopping-cart.component.css']
})
export class ShoppingCartComponent {
  constructor(public custS: CustomerService, public productS: ProductService, public router: Router, public CompletePurchaseService: CompletePurchaseService) { }
  note: string = "";
  delete(p: Product) {
    console.log(this.productS.shoppingCart);
    this.productS.AmountPaid -= p.price! * (p.quantity ?? 0);
    this.productS.shoppingCart = this.productS.shoppingCart.filter(item => item.productCode !== p.productCode);

  }

  back() {
    this.router.navigate(['']);
  }
  async sumPlus(p: any) {
    const index = this.productS.shoppingCart.findIndex(item => item?.productCode === p.productCode);
    if (index !== -1) {
      if (this.productS.shoppingCart[index].quantity! < this.productS.shoppingCart[index].quantityInStock!) {
        this.productS.shoppingCart[index].quantity! += 1;
        this.productS.AmountPaid += p.price ? p.price : 0;
      }
    }
  }
  async sumMinus(p: any) {
    const index = this.productS.shoppingCart.findIndex(item => item?.productCode === p.productCode);
    if (index !== -1) {
      if (this.productS.shoppingCart[index].quantity! > this.productS.shoppingCart[index].quantityInStock!) {
        this.productS.shoppingCart[index].quantity! -= 1;
        this.productS.AmountPaid -= p.price ? p.price : 0;
      }
    }
  }

  payment() {
    if (!this.custS.currentCustomer.customerName) {
      this.router.navigate(['/login']);
      return;
    }
    this.CompletePurchaseService.CompletePurchase.note = this.note;
    this.router.navigate(['/payment']);
  }

}