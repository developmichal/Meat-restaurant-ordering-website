import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../Services/category.service';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../Classes/Product';
import { CommonModule, NgClass, SlicePipe } from '@angular/common';

@Component({
  selector: 'app-card-home',
  standalone: true,
  imports: [CommonModule, NgClass,SlicePipe],
  templateUrl: './card-home.component.html',
  styleUrls: ['./card-home.component.css']
})
export class CardHomeComponent implements OnInit {
  arrProduct: Array<Product> = new Array<Product>();

  constructor(public cs: CategoryService, public ps: ProductService) { }

  ngOnInit(): void {
    this.ProductByCategoryCode();
  }

  async ProductByCategoryCode() {
    const categories = this.cs.allCategory; 
    for (const category of categories) {
      const products = await this.ProductsByCategory(category.categoryCode);
      this.ps.dictionary.push({ categoryName: category.categoryName, products }); 
    }
  }

  ProductsByCategory(categoryCode: number): Promise<Product[]> {
    return new Promise((resolve, reject) => {
      this.ps.productByCategoryCode(categoryCode).subscribe(
        succ => {
          resolve(succ); 
        },
        err => {
          console.log("error " + err.message);
          reject(err); 
        }
      );
    });
  }

  isArray(value: any): boolean {
    return Array.isArray(value);
  }
}
