import { Routes, RouterModule } from '@angular/router';
import { RolComponent } from './rol.component';
import { MainLayoutComponent } from '../layout/main-layout/main-layout.component';

const routes: Routes = [
  {
    path: 'rols',
    component: MainLayoutComponent,
    children: [
      { path: '', component: RolComponent }
    ]
  }
];

export const RolRoutes = RouterModule.forChild(routes);
