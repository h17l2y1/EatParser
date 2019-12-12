import { Routes, RouterModule } from '@angular/router';
import { RolComponent } from './rol.component';

const routes: Routes = [
  { path: '', component: RolComponent  },
];

export const RolRoutes = RouterModule.forChild(routes);
