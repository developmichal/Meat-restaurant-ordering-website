import { DatePipe, Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../Classes/Product';
import { ChangColorDirective } from '../../app/chang-color.directive';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [DatePipe, ChangColorDirective],
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  product: Product = new Product();
  constructor(private route: ActivatedRoute, public l: Location, public ps: ProductService) { }
  ngOnInit(): void {
    this.product = history.state.product;
  }

  back() {
    this.l.back();
  }
  async add(product: Product) {
    this.ps.itemCount++;
    const index = this.ps.shoppingCart.findIndex(p => p?.productCode === product.productCode);
    if (index !== -1) {
      this.ps.shoppingCart[index].quantity! += 1;
    }
    else {
      this.ps.shoppingCart.push(product);
      this.ps.shoppingCart[this.ps.shoppingCart.length - 1].quantity = 1;
    }
    this.ps.AmountPaid += product.price!;
    this.l.back();
  }
}
