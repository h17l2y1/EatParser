import { Routes, RouterModule } from '@angular/router';
import { SecondComponent } from './second.component';

const routes: Routes = [
  { path: '', component: SecondComponent }
];

export const SecondRoutes = RouterModule.forChild(routes);
