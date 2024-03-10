import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FAQGetAllEndpoint } from '../../endpoints/faq-endpoints/faq-get-all-endpoint';

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css',
})
export class HomepageComponent implements OnInit {
  constructor(
    private router: Router,
    private fAQGetAllEndpoint: FAQGetAllEndpoint
  ) {}

  podaciFAQ: any = null;
  jelVidljiv: boolean = false;
  prikaziFAQDiv: boolean = false;
  znak: any = '+';

  ngOnInit(): void {
    this.fetchFAQ();
  }

  fetchFAQ() {
    this.fAQGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.podaciFAQ = x;
      },
      error: (x) => {},
    });
  }

  showSignin() {
    this.jelVidljiv = !this.jelVidljiv;
  }
  showOdgovor() {
    this.prikaziFAQDiv = !this.prikaziFAQDiv;
    this.znak = this.prikaziFAQDiv ? '-' : '+';
  }
}
