import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../Services/customer.service';
import { Customer } from '../../Classes/Customer';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  loginCustomer:Customer=new Customer();
  ngOnInit(): void {

  }
  constructor(public login: CustomerService, public router: Router) { }
  getLogin() {
    this.login.login(this.login.newEmail).subscribe(
      succ => {       
         if (succ !== null) {
            this.login.currentCustomer = succ; 
            console.log(this.login.currentCustomer);
         } else {
          this.router.navigate(['/signUp']);

         }
      },
      err => { 
         console.log("error " + err.message) 
      }
    );
    this.router.navigate(['']);
}
  sign(){
    this.router.navigate(['/signUp']);
  }
}
