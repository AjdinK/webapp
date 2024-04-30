import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule, NgOptimizedImage } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [NgOptimizedImage, CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent {
  constructor(private router: Router) {}

  openMenu: boolean = false;

  logirajSe() {
    this.router.navigate(['/login']);
  }
  toggleMenu() {
    this.openMenu = !this.openMenu;
  }
}
