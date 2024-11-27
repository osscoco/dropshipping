import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

export interface Notification {
  message: string;
  type: 'success' | 'error' | 'info' | 'warning';
}

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  private notificationSubject = new BehaviorSubject<Notification | null>(null);
  public notification$: Observable<Notification | null> = this.notificationSubject.asObservable();

  constructor() {}

  showNotification(message: string, type: 'success' | 'error' | 'info' | 'warning' = 'info') {
    this.notificationSubject.next({ message, type });

    // Optionnel : Efface la notification après un délai, par exemple 5 secondes
    setTimeout(() => {
      this.clearNotification();
    }, 5000);
  }

  clearNotification() {
    this.notificationSubject.next(null);
  }
}