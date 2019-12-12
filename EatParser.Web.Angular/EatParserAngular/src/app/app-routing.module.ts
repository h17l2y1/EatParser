import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: () => import('./auth/login/login.module').then(m => m.LoginModule) },
  { path: 'login', loadChildren: () => import('./auth/login/login.module').then(m => m.LoginModule) },
  { path: 'menu', loadChildren: () => import('./pages/menu/menu.module').then(m => m.MenuModule) },
  { path: 'sets', loadChildren: () => import('./pages/set/set.module').then(m => m.SetModule) },
  { path: 'rols', loadChildren: () => import('./pages/rol/rol.module').then(m => m.RolModule) },
  { path: 'sushi', loadChildren: () => import('./pages/rol/rol.module').then(m => m.RolModule) },
  { path: 'pizza', loadChildren: () => import('./pages/rol/rol.module').then(m => m.RolModule) }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
