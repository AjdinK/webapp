import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterOutlet } from '@angular/router';
import { FAQGetAllEndpoint } from './endpoints/faq-endpoints/faq-get-all-endpoint';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(
    private router: Router //private fAQGetAllEndpoint: FAQGetAllEndpoint
  ) {}

  title = 'ITServiceCenter';
  jelVidljiv: boolean = false;
  prikaziFAQDiv: boolean = false;
  podaciFAQ: any = null;
  znak: any = '+';

  ngOnInit(): void {
    //this.fetchFAQ();
  }
  // fetchFAQ() {
  //   this.fAQGetAllEndpoint.obradi().subscribe({
  //     next: (x) => {
  //       this.podaciFAQ = x;
  //     },
  //     error: (x) => {},
  //   });
  // }

  showSignin() {
    this.jelVidljiv = !this.jelVidljiv;
  }
  showOdgovor() {
    this.prikaziFAQDiv = !this.prikaziFAQDiv;
    this.znak = this.prikaziFAQDiv ? '-' : '+';
  }
}
