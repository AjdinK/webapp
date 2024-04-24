import {Component, OnInit} from '@angular/core';
import {NgForOf, NgIf} from "@angular/common";
import {Router} from "@angular/router";
import {FAQGetAllEndpoint} from "../../../endpoints/faq-endpoints/faq-get-all-endpoint";

@Component({
  selector: 'app-faq',
  standalone: true,
    imports: [
        NgForOf,
        NgIf
    ],
  templateUrl: './faq.component.html',
  styleUrl: './faq.component.css'
})
export class FaqComponent implements OnInit {
  constructor( private fAQGetAllEndpoint: FAQGetAllEndpoint ) {}
  ngOnInit(): void { this.fetchFAQ(); }

  podaciFAQ: any = null;
  pitanje: { [key: number]: boolean } = {};

  fetchFAQ() {
    this.fAQGetAllEndpoint.obradi().subscribe({
      next: (x) => {
        this.podaciFAQ = x.faqLista;
        this.podaciFAQ.forEach ((q:any) => this.pitanje[q.id] = false);
      },
      error: (x) => { }
    });
  }

  showOdgovor(id: number) {
    this.pitanje[id] = !this.pitanje[id];
  }
}
