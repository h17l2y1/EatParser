import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SecondRoutes } from './second.routing';
import { SecondComponent } from './second.component';

@NgModule({
  declarations: [
    SecondComponent
  ],
  imports: [
    CommonModule,
    SecondRoutes
  ]
})
export class SecondModule { }
