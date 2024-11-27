import { inject, Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { NotificationService } from '../../services/notification/notification.service';
import { AuthService } from '../../services/auth/auth.service';
import { ResponseApi } from '../../models/responseApi.model';
import { catchError, map, Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AlreadyAuthGuard implements CanActivate {

  authService = inject(AuthService);
  notificationService: NotificationService = inject(NotificationService);
  router: Router = inject(Router);
  
  constructor() {}

  canActivate(route: ActivatedRouteSnapshot): Observable<boolean> {
    return this.authService.isAuthenticated().pipe(
      map((response: boolean) => {
        if (!response) {
          return true;
        }
        else {
          this.notificationService.showNotification("Vous êtes déjà connecté", 'error');
          this.router.navigateByUrl('dashboard');
          return false;
        }
      }),
      catchError(() => {
        // En cas d'erreur (comme une 401 non authentifié), ne pas permettre l'accès
        this.notificationService.showNotification("401 Already", 'error');
        this.router.navigateByUrl('dashboard');
        return of(false);
      })
    );
  }
}
