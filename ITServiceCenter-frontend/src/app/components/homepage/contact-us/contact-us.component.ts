import { Component } from '@angular/core';
import {CommonModule, NgOptimizedImage} from "@angular/common";
import {FormsModule, NgForm} from "@angular/forms";
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

  async posalji (form:NgForm) {
  if (form.form.valid){
  emailjs.init("rs86oYSzchfvEtq82");
    let response = await emailjs.send("service_jqhy61m","template_o0gkayw",{
    from_name: this.porukaKontakt.ime,
    to_name: "Ajdin.kuduzovic@gmail.com",//itservicercenter@gmail.com
    from_user: this.porukaKontakt.email,
    message: this.porukaKontakt.message,
    reply_to: "test",
  });
    alert("Vasa Poruka poslata")
    this.clearForm();
  }
  else
    this.JelPoslano = true;
}

    private clearForm() {
      this.porukaKontakt.ime="";
      this.porukaKontakt.email="";
      this.porukaKontakt.poruka="";
      this.JelPoslano = false;
  }

}
