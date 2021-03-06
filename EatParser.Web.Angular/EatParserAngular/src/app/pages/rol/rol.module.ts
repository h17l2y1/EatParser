import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RolComponent } from './rol.component';
import { RolRoutes } from './rol.routing';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SliderModule } from 'src/app/shared/components/slider/slider.module';

@NgModule({
  declarations: [
    RolComponent,
  ],
  imports: [
    CommonModule,
    RolRoutes,
    BrowserModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    FormsModule,
    SliderModule
  ]
})
export class RolModule { }
