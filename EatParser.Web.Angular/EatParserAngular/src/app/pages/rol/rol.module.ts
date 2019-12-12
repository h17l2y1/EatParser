import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RolComponent } from './rol.component';
import { RolRoutes } from './rol.routing';

@NgModule({
  imports: [
    CommonModule,
    RolRoutes
  ],
  declarations: [RolComponent]
})
export class RolModule { }
