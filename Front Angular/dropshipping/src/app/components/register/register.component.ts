import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth/auth.service';
import { Router } from '@angular/router';
import { User } from '../../models/user.model';
import { NotificationService } from '../../services/notification/notification.service';
import { ResponseApi } from '../../models/responseApi.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormsModule
  ]
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup = new FormGroup([]);
  newUser: User | undefined;
  successMessage: string = '';
  errorMessage: string = '';

  fb: FormBuilder = inject(FormBuilder);
  authService: AuthService = inject(AuthService);
  router: Router = inject(Router);
  notificationService: NotificationService = inject(NotificationService);

  constructor() {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      contactPhone: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      roleId: ['', Validators.required]
    });

    //Role "Utilisateur" par défaut
    this.registerForm.controls['roleId'].setValue('1');
  }

  register() {
    if (this.registerForm.valid) {
      this.newUser = new User(
        this.registerForm.controls['firstName'].value,
        this.registerForm.controls['lastName'].value,
        this.registerForm.controls['email'].value,
        this.registerForm.controls['password'].value,
        this.registerForm.controls['contactPhone'].value,
        this.registerForm.controls['dateOfBirth'].value,
        this.registerForm.controls['roleId'].value
      )
      this.authService.register(this.newUser).subscribe({
        next: (response: ResponseApi) => {
          if (response.success) {
            this.notificationService.showNotification(response.message, 'success');
            this.router.navigate(['/login']);
          } else {
            this.notificationService.showNotification(response.message, 'error');
          }
        },
        error: () => {
          this.notificationService.showNotification('Une erreur est survenue ...', "error");
        }
      });
    }
  }
}
