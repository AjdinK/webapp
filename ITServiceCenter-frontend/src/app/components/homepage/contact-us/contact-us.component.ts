import { Component } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import emailjs, { type EmailJSResponseStatus } from '@emailjs/browser';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-contact-us',
  standalone: true,
  imports: [NgOptimizedImage, FormsModule, CommonModule,TranslateModule],
  templateUrl: './contact-us.component.html',
  styleUrl: './contact-us.component.css',
})
export class ContactUsComponent {
  constructor() {}

  // to show the error if the fields are empty when press on sumbit
  JelPopunjeno: boolean = false;

  // new object to send the data and the poruka
  porukaKontakt: any = {
    ime: '',
    email: '',
    poruka: '',
  };

  // using EMAILJS service to send the data from object (porukaKontakt) to the email without using backend
  async posalji(form: NgForm) {
    if (form.form.valid) {
      emailjs.init('rs86oYSzchfvEtq82');

      let response = await emailjs.send('service_jqhy61m', 'template_o0gkayw', {
        from_name: this.porukaKontakt.ime,
        to_name: 'ajdin.kuduzovic@gmail.com', //itservicercenter@gmail.com
        from_user: this.porukaKontakt.email,
        message: this.porukaKontakt.message,
        reply_to: 'test',
      });

      alert('Vasa Poruka poslata');
      this.clearForm();
    } else this.JelPopunjeno = true;
  }

  // clear the form after sending the data
  clearForm() {
    this.porukaKontakt.ime = '';
    this.porukaKontakt.email = '';
    this.porukaKontakt.poruka = '';
    this.JelPopunjeno = false;
  }
}
