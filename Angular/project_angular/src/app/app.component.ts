import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from '../Comps/nav/nav.component';
import { CategoryService } from '../Services/category.service';
import { ProductService } from '../Services/product.service';
import { AllFooterComponent } from '../Comps/all-footer/all-footer.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavComponent, AllFooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'Project';
  loading: boolean = true; 

  ngOnInit(): void {
    this.getCategory();
  }
  constructor(public cs: CategoryService) { }

  async getCategory() {
    await this.cs.getC().subscribe(
      d => {
        this.cs.allCategory = d;
        this.loading = false;
      },
      err => { console.log("error " + err.message) }
    );
  }
}
