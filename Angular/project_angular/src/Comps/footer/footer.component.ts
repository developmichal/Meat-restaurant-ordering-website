import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css'
})
export class FooterComponent implements OnInit {
  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.fragment.subscribe(fragment => {
      if (fragment === 'contact-footer') {
        const footer = document.getElementById(fragment);
        if (footer) {
          footer.scrollIntoView({ behavior: 'smooth', block: 'start' });
        }
      }
    });
  }
}
