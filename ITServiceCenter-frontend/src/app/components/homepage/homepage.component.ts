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
  pitanje: { [key: number]: boolean } = {};

  ngOnInit(): void {
    this.fetchFAQ();
  }

  fetchFAQ() {
    this.fAQGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.podaciFAQ = x.faqLista;
        this.podaciFAQ.forEach((q:any) => this.pitanje[q.id] = false);
      },
      error: (x) => {},
    });
  }

  showOdgovor(id: number) {
    this.pitanje[id] = !this.pitanje[id];
  }
}
