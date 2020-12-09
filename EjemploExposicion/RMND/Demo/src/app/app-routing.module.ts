import { AdminHomeComponent } from './admin-home/admin-home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AdminGuardGuard } from './admin-guard.guard';

const routes: Routes = 
[
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'home',
    component: AdminHomeComponent, canActivate: [AdminGuardGuard]
  },
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
