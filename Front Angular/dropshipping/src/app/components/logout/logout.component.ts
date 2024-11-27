import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationService } from '../../services/notification/notification.service';
import { AuthService } from '../../services/auth/auth.service';

@Component({
  selector: 'app-logout',
  template: '',
})
export class LogoutComponent implements OnInit {

  notificationService: NotificationService = inject(NotificationService);
  router: Router = inject(Router);
  authService: AuthService = inject(AuthService);

  constructor() {}

  ngOnInit(): void {
    this.authService.logout();
  }
}
