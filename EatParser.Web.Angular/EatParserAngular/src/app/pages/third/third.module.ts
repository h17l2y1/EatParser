import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThirdRoutes } from './third.routing';
import { ThirdComponent } from './third.component';

@NgModule({
  declarations: [
    ThirdComponent
  ],
  imports: [
    CommonModule,
    ThirdRoutes
  ]
})
export class ThirdModule { }