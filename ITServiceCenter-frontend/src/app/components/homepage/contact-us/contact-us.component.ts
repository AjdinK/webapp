import { Component } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import emailjs, { type EmailJSResponseStatus } from '@emailjs/browser';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-contact-us',
  standalone: true,
   imports: [NgOptimizedImage , ReactiveFormsModule, CommonModule,TranslateModule],
  templateUrl: './contact-us.component.html',
  styleUrl: './contact-us.component.css',
})
export class ContactUsComponent {

  kontaktForm : FormGroup;

  constructor() {
    this.kontaktForm = new FormGroup({
      ime: new FormControl('',[Validators.required,Validators.minLength(3)]),
      email : new FormControl('',[Validators.required,Validators.email]),
      poruka: new FormControl('',[Validators.required,Validators.maxLength(20)]),
    })
  }

  // to show the error if the fields are empty when press on sumbit
  JelPopunjeno: boolean = false;


  // using EMAILJS service to send the data from object (kontaktForm) to the email without using backend
  async posalji() {
    if (this.kontaktForm.valid) {
      emailjs.init('rs86oYSzchfvEtq82');

      let response = await emailjs.send('service_jqhy61m', 'template_o0gkayw', {
        from_name: this.kontaktForm.controls['ime'].value,
        to_name: 'ajdin.kuduzovic@gmail.com', //itservicercenter@gmail.com
        from_user: this.kontaktForm.controls['email'].value,
        message: this.kontaktForm.controls['poruka'].value,
        reply_to: 'test',
      });

      alert('Vasa Poruka poslata');
      this.clearForm();
    } else this.JelPopunjeno = true;
  }

  // clear the form after sending the data
  clearForm() {
    this.kontaktForm.controls['ime'].reset();
    this.kontaktForm.controls['email'].reset();
    this.kontaktForm.controls['poruka'].reset();
    this.JelPopunjeno = false;
  }
}
