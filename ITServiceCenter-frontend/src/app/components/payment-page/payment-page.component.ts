import { Component } from '@angular/core';
import {HeaderComponent} from "../homepage/header/header.component";
import {Router} from "@angular/router";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-payment-page',
  standalone: true,
  imports: [
    HeaderComponent,
    NgIf
  ],
  templateUrl: './payment-page.component.html',
  styleUrl: './payment-page.component.css'
})
export class PaymentPageComponent {

constructor(private router: Router) {
}

  paymentSuccess: boolean = false;

  confirmPayment() {
    this.paymentSuccess = true;

    console.log('Plaćanje potvrđeno.');
  }

  goToHomePage() {
    this.router.navigate(['/']);
  } 
}
