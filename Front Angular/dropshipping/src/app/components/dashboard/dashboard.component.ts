import { Component, inject, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from '../../interceptors/auth/auth.interceptor';
import { Router } from '@angular/router';
import { HeadingComponent } from '../../shared-components/heading/heading.component';
import { TableComponent } from '../../shared-components/table/table.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  standalone: true,
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  imports: [
    HeadingComponent,
    TableComponent
  ]
})
export class DashboardComponent implements OnInit {

  authService: AuthService = inject(AuthService);
  router: Router = inject(Router);
  
  constructor() {}

  ngOnInit(): void {
  }

  logout() {
    this.router.navigateByUrl('/logout');
  }
}
