import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../Services/category.service';
import { CommonModule } from '@angular/common';
import { ProductService } from '../../Services/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent implements OnInit {
  ngOnInit(): void {
    this.getCategory();
  }
  constructor(public cs: CategoryService, public ps: ProductService, public router: Router) { }
  getCategory() {
    this.cs.getC().subscribe(
      d => { this.cs.allCategory = d; },
      err => { console.log("error " + err.message) }
    );
  }
  filtering(c: number) {
    this.router.navigate([`./filter/${c}`])
  }
  login() {
    this.router.navigate(['./login'])
  }
  cart() {
    this.router.navigate(['./shoppingCart'])
  }
  home() {
    this.router.navigate([''])
  }
  navigateToFooter() {
    this.router.navigate([], { fragment: 'contact-footer' });
  }
  navigateToAbout() {
    const section = document.getElementById("about-section");
    if (section) {
      section.scrollIntoView({ behavior: "smooth", block: "start" });
    }
  }
}

