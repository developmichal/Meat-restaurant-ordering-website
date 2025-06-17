import { Component } from '@angular/core';
import { CustomerService } from '../../Services/customer.service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Customer } from '../../Classes/Customer';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.css'
})
export class SignUpComponent {
  ngOnInit(): void {
  }
  constructor(public sign_up: CustomerService, public router: Router) { }
  getSign() {
    this.sign_up.sign_up().subscribe(
      succ => {
        this.sign_up.currentCustomer = succ,
          console.log(this.sign_up.currentCustomer);
      },
      err => { console.log("error " + err.message) }
    )
    this.router.navigate(['']);
  }
}
