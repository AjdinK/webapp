import { Component } from '@angular/core';
import {CommonModule, NgOptimizedImage} from "@angular/common";
import {FormsModule} from "@angular/forms";

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

  posalji() {
  this.JelPoslano = true;
  }
}
