import { Routes, RouterModule } from '@angular/router';
import { SetComponent } from './set.component';
import { MainLayoutComponent } from '../layout/main-layout/main-layout.component';

const routes: Routes = [
  {
    path: 'sets',
    component: MainLayoutComponent,
    children: [
      { path: '', component: SetComponent }
    ]
  }
];

export const SetRoutes = RouterModule.forChild(routes);
