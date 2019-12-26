import { Routes, RouterModule } from '@angular/router';
import { MainLayoutComponent } from '../layout/main-layout/main-layout.component';
import { PizzaComponent } from './pizza.component';

const routes: Routes = [
  {
    path: 'pizza',
    component: MainLayoutComponent,
    children: [
      { path: '', component: PizzaComponent }
    ]
  }
];

export const PizzaRoutes = RouterModule.forChild(routes);
