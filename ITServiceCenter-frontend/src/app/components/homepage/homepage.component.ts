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
export class HomepageComponent {
  constructor(
    private router: Router,
    private fAQGetAllEndpoint: FAQGetAllEndpoint
  ) {}

  fetchFAQ() {}
  jelVidljiv: boolean = false;
  prikaziFAQDiv: boolean = false;
  podaciFAQ: any = null;
  znak: any = '+';

  showSignin() {
    this.jelVidljiv = !this.jelVidljiv;
  }
  showOdgovor() {
    this.prikaziFAQDiv = !this.prikaziFAQDiv;
    this.znak = this.prikaziFAQDiv ? '-' : '+';
  }
}
