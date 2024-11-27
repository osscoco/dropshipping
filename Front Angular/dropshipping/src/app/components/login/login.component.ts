import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserLogin } from '../../models/user.model';
import { NotificationService } from '../../services/notification/notification.service';
import { ResponseApi } from '../../models/responseApi.model';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from '../../interceptors/auth/auth.interceptor';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ]
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup = new FormGroup([]);
  error: string = '';
  newUser: UserLogin | undefined;

  fb: FormBuilder = inject(FormBuilder);
  authService: AuthService = inject(AuthService);
  router: Router = inject(Router);
  notificationService: NotificationService = inject(NotificationService);
  route: ActivatedRoute = inject(ActivatedRoute);
  
  constructor() {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });

    // if (!localStorage.getItem('token')) {
    //   this.route.queryParams.subscribe(params => {
    //     if (params['message']) {
    //       this.notificationService.showNotification(params['message'], params['type'] || 'info');
    //     }
    //   });
    // }
  }

  login() {
    if (this.loginForm.valid) {
      this.newUser = new UserLogin(
        this.loginForm.controls['email'].value,
        this.loginForm.controls['password'].value
      );
      this.authService.login(this.newUser).subscribe({
        next: (response: ResponseApi) => {
          if (response.success) {
            localStorage.setItem('token', response.data.token);
            this.notificationService.showNotification(response.message, 'success');
            this.router.navigate(['/dashboard']);
          } else {
            this.notificationService.showNotification(response.message, 'error');
            this.router.navigate(['/login']);
          }
        },
        error: () => {
          this.notificationService.showNotification("Echec de connexion ...", 'error');
          this.router.navigate(['/login']);
        }
      });
    }
  }
}
