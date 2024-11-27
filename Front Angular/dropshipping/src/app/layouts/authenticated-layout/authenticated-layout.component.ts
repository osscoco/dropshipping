import { AfterViewInit, Component, inject } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-authenticated-layout',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './authenticated-layout.component.html',
  styleUrl: './authenticated-layout.component.scss'
})
export class AuthenticatedLayoutComponent implements AfterViewInit {

  router: Router = inject(Router);

  logout() {
    this.router.navigateByUrl('/logout');
  }

  ngAfterViewInit(): void {
    import('flowbite').then((flowbite) => {
      const drawerToggle = document.getElementById('drawer-toggle');
      const drawer = document.getElementById('logo-sidebar');
      if (drawerToggle && drawer) {
        // Appel explicite de Flowbite pour initialiser le drawer
        const drawerInstance = new (window as any).Drawer(drawer);
        drawerToggle.addEventListener('click', () => drawerInstance.toggle());
      }
    }).catch(err => {
      console.error('Flowbite initialization failed:', err);
    });
  }
}
