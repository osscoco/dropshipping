import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-anonymous-layout',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './anonymous-layout.component.html',
  styleUrl: './anonymous-layout.component.scss'
})
export class AnonymousLayoutComponent {
  activeRoute: string = '';

  constructor(private router: Router) {}

  // Méthode pour naviguer et définir la classe active
  navigateTo(route: string) {
    this.activeRoute = route; // Met à jour la route active
    this.router.navigate([route]); // Redirige vers la route
  }
}
