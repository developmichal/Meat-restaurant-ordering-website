import { Component, CUSTOM_ELEMENTS_SCHEMA, EventEmitter, Input, Output } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cards',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css'],
})
export class CardsComponent {
  ngOnInit(): void {
  }
  @Input() productCode : number = 0;
  @Input() productName: string = ""
  @Input() categoryCode: number = 0; 
  @Input() productDescription: string | undefined
  @Input() price: number = 0
  @Input() picture: string = ""
  @Input() QuantityInStock: number = 0
  @Input() LastUpdateDate: string | undefined
  @Input() quantity: number = 0
  
  constructor(public ps: ProductService) { }
  @Output() sendTo = new EventEmitter()
  send() {
    const product = {
      productCode: this.productCode,
      productName: this.productName,
      categoryCode: this.categoryCode,
      productDescription: this.productDescription,
      price: this.price,
      picture: this.picture,
      quantityInStock: this.QuantityInStock,
      lastUpdateDate: this.LastUpdateDate,
      quantity: this.quantity      
    };
    this.sendTo.emit(product);
  }

 
}