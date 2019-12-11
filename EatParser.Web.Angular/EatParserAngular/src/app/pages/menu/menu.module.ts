import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainRoutes } from './menu.routing';
import { MenuComponent } from './menu.component';

@NgModule({
  declarations: [
    MenuComponent
  ],
  imports: [
    CommonModule,
    MainRoutes,
  ]
})
export class MenuModule { }
