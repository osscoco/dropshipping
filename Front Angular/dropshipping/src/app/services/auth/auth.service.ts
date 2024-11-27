import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError, map, Observable, of } from 'rxjs';
import { User, UserLogin } from '../../models/user.model';
import { NotificationService } from '../notification/notification.service';
import { ResponseApi } from '../../models/responseApi.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5180/api/Auth'; // Remplace par ton API

  notificationService: NotificationService = inject(NotificationService);
  http: HttpClient = inject(HttpClient);
  router: Router = inject(Router);

  constructor() {}

  me(): Observable<string | null> {
    return this.http.get<ResponseApi>(`${this.apiUrl}/me`).pipe(
      map(response => response.data.value),
      catchError(err => {
        if (err.status === 401) {
          return of(null);
        }
        throw err;
      })
    );
  }

  isAuthenticated(): Observable<boolean> {
    return this.http.get<{ success: boolean }>(`${this.apiUrl}/me`).pipe(
      map(response => response.success),
      catchError(err => {
        if (err.status === 401) {
          return of(false);
        }
        throw err;
      })
    );
  }

  login(newUser: UserLogin): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, 
      { 
        email: newUser.email, 
        password: newUser.password 
      }
    );
  }

  register(newUser: User): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, 
      { 
        firstName: newUser.firstName,
        lastName: newUser.lastName,
        email: newUser.email,
        password: newUser.password,
        contactPhone: newUser.contactPhone,
        dateOfBirth: newUser.dateOfBirth,
        roleId: newUser.roleId
       }
    );
  }

  logout() {
    localStorage.removeItem('token');
    this.notificationService.showNotification('Déconnexion réussie', 'success');
    this.router.navigateByUrl('/login');
  }
}
