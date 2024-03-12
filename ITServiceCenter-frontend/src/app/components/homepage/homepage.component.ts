import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FAQGetAllEndpoint } from '../../endpoints/faq-endpoints/faq-get-all-endpoint';
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [CommonModule, FormsModule],
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
  znak: string = '+';
  pitanje : any = null;

  ngOnInit(): void {
    this.fetchFAQ();
  }

  fetchFAQ() {
    this.fAQGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.podaciFAQ = x.faqLista;
      },
      error: (x) => {},
    });
  }

  showSignin() {
    this.jelVidljiv = !this.jelVidljiv;
  }
  showOdgovor(x: any) {
      this.pitanje = x;
      this.prikaziFAQDiv = !this.prikaziFAQDiv;
      this.znak = this.prikaziFAQDiv ? '-' : '+';
  }
}
