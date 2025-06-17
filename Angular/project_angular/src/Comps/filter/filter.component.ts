import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../Classes/Product';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { CardsComponent } from '../cards/cards.component';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-filter',
  standalone: true,
  imports: [CardsComponent, RouterOutlet, FormsModule],
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {
  p: any;
  constructor(public ps: ProductService, public paramsRoutes: ActivatedRoute, public router: Router) { }
  isOk: boolean = false;
  products: Array<Product> = new Array<Product>();
  myParam: number = 0;
  // filteredProducts = [...this.products]; 
  minPrice = 10;
  maxPrice = 600;
  selectedMinPrice = this.minPrice;
  selectedMaxPrice = this.maxPrice;
  minTooltipPosition = 0;
  maxTooltipPosition = 100;
  showPriceFilter = false;
  ngOnInit(): void {
    this.paramsRoutes.params.subscribe(params => { // השתנה מ-queryParams ל-params
      this.myParam = Number(params['codeCategory']); // המרת הפרמטר למספר
      console.log(this.myParam);
      this.ProductsByCategory(this.myParam);
    });
  }

  ProductsByCategory(categoryCode: number) {
    this.ps.productByCategoryCode(categoryCode).subscribe(
      succ => {
        console.log(succ);
        this.products = succ;
        this.isOk = true;
      },
      err => {
        console.log("error " + err.message);
      }
    );
  }

  send(product: any) {
    console.log('Product sent to details:', product);
    this.router.navigate(['details'], {
      relativeTo: this.paramsRoutes,
      state: { product: product }
    });

  }
  sortToMax() {
    this.products.sort((a, b) => a.price! - b.price!);
  }
  sortToMin() {
    this.products.sort((a, b) => b.price! - a.price!);
  }
  filterPrice() {
    console.log("===" + this.myParam);

    this.ps.productByPrice(this.myParam, this.selectedMinPrice, this.selectedMaxPrice).subscribe(
      succ => {
        console.log(succ);
        this.products = succ;
      },
      err => {
        console.log("error " + err.message);
      }
    );
  }

  togglePriceFilter() {
    this.showPriceFilter = !this.showPriceFilter;
  }

  updateRange() {
    if (this.selectedMinPrice > this.selectedMaxPrice) {
      [this.selectedMinPrice, this.selectedMaxPrice] = [this.selectedMaxPrice, this.selectedMinPrice];
    }

    this.minTooltipPosition = ((this.selectedMinPrice - this.minPrice) / (this.maxPrice - this.minPrice)) * 100;
    this.maxTooltipPosition = ((this.selectedMaxPrice - this.minPrice) / (this.maxPrice - this.minPrice)) * 100;

    this.filterPrice();
    this.updateSliderTrack();
  }

  updateSliderTrack() {
    const track = document.querySelector('.slider-track') as HTMLElement;
    const percentMin = ((this.selectedMinPrice - this.minPrice) / (this.maxPrice - this.minPrice)) * 100;
    const percentMax = ((this.selectedMaxPrice - this.minPrice) / (this.maxPrice - this.minPrice)) * 100;
    track.style.left = `${percentMin}%`;
    track.style.right = `${100 - percentMax}%`;
  }
  getSliderRangeWidth() {
    const range = this.selectedMaxPrice - this.selectedMinPrice;
    const total = this.maxPrice - this.minPrice;
    return (range / total) * 100;
  }


  getSliderRangeLeft() {
    const leftRange = this.selectedMinPrice - this.minPrice;
    const total = this.maxPrice - this.minPrice;
    return (leftRange / total) * 100;
  }


}
