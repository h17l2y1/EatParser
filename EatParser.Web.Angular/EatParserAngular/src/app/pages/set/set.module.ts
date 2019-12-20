import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SetComponent } from './set.component';
import { SetRoutes } from './set.routing';
import { IgxInputGroupModule, IgxSliderModule } from 'igniteui-angular';
import { SliderComponent } from 'src/app/shared/components/slider/slider.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    SetComponent,
    SliderComponent
  ],
  imports: [
    CommonModule,
    SetRoutes,
    BrowserModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    FormsModule,
    IgxInputGroupModule,
    IgxSliderModule
  ]
})
export class SetModule { }
