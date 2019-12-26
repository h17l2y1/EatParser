import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  // { path: 'login', loadChildren: () => import('./auth/login/login.module').then(m => m.LoginModule) },
  { path: 'menu', loadChildren: () => import('./pages/menu/menu.module').then(m => m.MenuModule) },
  { path: 'sets', loadChildren: () => import('./pages/set/set.module').then(m => m.SetModule) },
  { path: 'rols', loadChildren: () => import('./pages/rol/rol.module').then(m => m.RolModule) },
  { path: 'sushi', loadChildren: () => import('./pages/sushi/sushi.module').then(m => m.SushiModule) },
  { path: 'pizza', loadChildren: () => import('./pages/pizza/pizza.module').then(m => m.PizzaModule) },
];

export const AppRoutes = RouterModule.forChild(routes);
