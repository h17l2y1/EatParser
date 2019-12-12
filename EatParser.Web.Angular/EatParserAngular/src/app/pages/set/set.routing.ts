import { Routes, RouterModule } from '@angular/router';
import { SetComponent } from './set.component';

const routes: Routes = [
  { path: '', component: SetComponent },
];

export const SetRoutes = RouterModule.forChild(routes);
