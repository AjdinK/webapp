import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-search-bar',
  standalone: true,
  imports: [FormsModule, NgIf],
  templateUrl: './search-bar.component.html',
  styleUrl: './search-bar.component.css',
})
export class SearchBarComponent {
  constructor() {}

  jelPopunjeno: boolean = false;

  pretregaObj: any = {
    id: 0,
    sifra: '',
  };
  pretrega() {
    this.jelPopunjeno = true;
    throw new Error('Method not implemented.');
  }
}
