import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AuthGuard } from './guards/auth/auth.guard';
import { AlreadyAuthGuard } from './guards/already-auth/already-auth.guard';
import { AnonymousLayoutComponent } from './layouts/anonymous-layout/anonymous-layout.component';
import { AuthenticatedLayoutComponent } from './layouts/authenticated-layout/authenticated-layout.component';
import { RegisterComponent } from './components/register/register.component';
import { LogoutComponent } from './components/logout/logout.component';

export const routes: Routes = [
  {
    path: '',
    component: AnonymousLayoutComponent,
    children: [
      { 
        path: 'login', 
        component: LoginComponent, 
        canActivate: [AlreadyAuthGuard] 
      },
      { 
        path: 'register', 
        component: RegisterComponent, 
        canActivate: [AlreadyAuthGuard] 
      },
      { 
        path: '', 
        redirectTo: 'login', 
        pathMatch: 'full' 
      },
    ]
  },
  {
    path: '',
    component: AuthenticatedLayoutComponent,
    children: [
      { 
        path: 'dashboard', 
        component: DashboardComponent,
        canActivate: [AuthGuard]
      },
      { 
        path: 'logout', 
        component: LogoutComponent,
        canActivate: [AuthGuard]
      }
    ]
  },
  { 
    path: '**', 
    redirectTo: '' 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
