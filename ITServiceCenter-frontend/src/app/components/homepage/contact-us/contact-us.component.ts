import { Component } from '@angular/core';
import {CommonModule, NgOptimizedImage} from "@angular/common";
import {FormsModule} from "@angular/forms";
import emailjs, { type EmailJSResponseStatus } from '@emailjs/browser';

@Component({
  selector: 'app-contact-us',
  standalone: true,
  imports: [
    NgOptimizedImage,
    FormsModule,
    CommonModule
  ],
  templateUrl: './contact-us.component.html',
  styleUrl: './contact-us.component.css'
})
export class ContactUsComponent {
  constructor( ) {}

  JelPoslano : boolean = false;

  porukaKontakt:any = {
    ime:'',
    email:'',
    poruka:'',
  }

  async posalji(porukaKontakt:any) {
  this.JelPoslano = true;
  emailjs.init("rs86oYSzchfvEtq82");
    let response = await emailjs.send("service_jqhy61m","template_o0gkayw",{
    from_name: porukaKontakt.ime,
    to_name: "Ajdin.kuduzovic@gmail.com",//itservicercenter@gmail.com
    from_user: porukaKontakt.email,
    message: porukaKontakt.message,
    reply_to: "test",
  });
    alert("Vasa Poruka poslata")
    this.clearForm();
}

  private clearForm() {
      this.porukaKontakt.ime="";
      this.porukaKontakt.email="";
      this.porukaKontakt.poruka="";
      this.JelPoslano = false;
  }
  
}
