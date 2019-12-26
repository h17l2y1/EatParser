import { Routes, RouterModule } from '@angular/router';
import { MainLayoutComponent } from '../layout/main-layout/main-layout.component';
import { SushiComponent } from './sushi.component';

const routes: Routes = [
  {
    path: 'sushi',
    component: MainLayoutComponent,
    children: [
      { path: '', component: SushiComponent }
    ]
  }
];

export const SushiRoutes = RouterModule.forChild(routes);
