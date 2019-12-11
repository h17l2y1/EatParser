import { Routes, RouterModule } from '@angular/router';
import { ThirdComponent } from './third.component';

const routes: Routes = [
  { path: '', component: ThirdComponent },
];

export const ThirdRoutes = RouterModule.forChild(routes);



