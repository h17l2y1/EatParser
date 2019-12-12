import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SetComponent } from './set.component';
import { SetRoutes } from './set.routing';

@NgModule({
  declarations: [
    SetComponent
  ],
  imports: [
    CommonModule,
    SetRoutes
  ]
})
export class SetModule { }
