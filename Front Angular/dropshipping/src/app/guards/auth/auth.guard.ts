import { inject, Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { NotificationService } from '../../services/notification/notification.service';
import { catchError, map, Observable, of } from 'rxjs';
import { AuthService } from '../../services/auth/auth.service';
import { ResponseApi } from '../../models/responseApi.model';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  authService = inject(AuthService);
  notificationService: NotificationService = inject(NotificationService);
  router: Router = inject(Router);

  constructor() {}

  canActivate(route: ActivatedRouteSnapshot): Observable<boolean> {
    return this.authService.isAuthenticated().pipe(
      map((success: boolean) => {
        if (success) {
          return true;
        }
        else {
          this.notificationService.showNotification("Vous devez être connecté", 'error');
          this.router.navigateByUrl('/login');
          return false;
        }
      }),
      catchError(() => {
        // En cas d'erreur (comme une 401 non authentifié), ne pas permettre l'accès
        this.notificationService.showNotification("Vous devez être connecté", 'error');
        this.router.navigateByUrl('/login');
        return of(false);
      })
    );
  }
}
