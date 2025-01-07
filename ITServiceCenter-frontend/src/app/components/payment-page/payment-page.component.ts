import { Component } from '@angular/core';
import {HeaderComponent} from "../homepage/header/header.component";
import {Router} from "@angular/router";
import {NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-payment-page',
  standalone: true,
  imports: [
    HeaderComponent,
    NgIf,
    FormsModule
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

  cardNumber: string = '';
  expiryDate: string = '';
  cvv: string = '';
  cardType: string = '';

  detectCardType(cardNumber: string): string {
    const number = cardNumber.replace(/\s+/g, '');
    if (/^4/.test(number)) return 'VISA';
    if (/^5[1-5]/.test(number)) return 'MASTERCARD';
    if (/^3[47]/.test(number)) return 'AMEX';
    return '';
  }

  onCardNumberInput(event: any): void {
    let value = event.target.value.replace(/\s+/g, '').replace(/[^0-9]/gi, '');
    let formattedValue = '';

    // Format card number with spaces
    for (let i = 0; i < value.length; i++) {
      if (i > 0 && i % 4 === 0) {
        formattedValue += ' ';
      }
      formattedValue += value[i];
    }

    this.cardNumber = formattedValue;
    this.cardType = this.detectCardType(value);
  }

  onExpiryDateInput(event: any): void {
    let value = event.target.value.replace(/\D/g, '');
    if (value.length >= 2) {
      value = value.slice(0, 2) + '/' + value.slice(2, 4);
    }
    this.expiryDate = value;
  }

  onCVVInput(event: any): void {
    this.cvv = event.target.value.replace(/\D/g, '');
  }

  isFormValid(): boolean {
    return (
        this.cardNumber.replace(/\s+/g, '').length >= 15 &&
        this.expiryDate.length === 5 &&
        this.cvv.length === 3
    );
  }
}
