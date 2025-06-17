import { Component } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Router } from '@angular/router';
import { CompletePurchaseService } from '../../Services/complete-purchase.service';
import Swal from 'sweetalert2';
import { FormsModule } from '@angular/forms';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-payment',
  standalone: true,
  imports: [FormsModule, NgClass],
  templateUrl: './payment.component.html',
  styleUrls: ['../shopping-cart/bootstrap.min.css', './payment.component.css']
})
export class PaymentComponent {
  constructor(public router: Router, public prodS: ProductService, public CompletePurchaseService: CompletePurchaseService) { }
  cardholderName: string = '';
  cardNumber: string = '';
  expirationDate: string = '';
  cvv: string = '';
  finish() {
    this.CompletePurchaseService.finish().subscribe({
      next: (response: any) => {
        console.log('Purchase successful:', response);

        Swal.fire({
          icon: 'success',
          title: 'רכישה הושלמה בהצלחה!',
          text: `קוד הרכישה שלך הוא: ${response.purchaseCode || response}`,
          confirmButtonText: 'אישור',
        }).then(() => {
          this.prodS.shoppingCart = [];
          this.prodS.itemCount = 0;
          this.router.navigate(['']);
        });
      },
      error: (error: any) => {
        console.error('Error during purchase:', error);

        Swal.fire({
          icon: 'error',
          title: 'שגיאה בתהליך הרכישה',
          text: `נא לנסות שוב מאוחר יותר. שגיאה: ${error.message || 'לא ידוע'}`,
          confirmButtonText: 'סגור',
        });
      },
    });
  }
}
