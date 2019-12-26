import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PizzaComponent } from './pizza.component';
import { PizzaRoutes } from './pizza.routing';
import { IgxInputGroupModule, IgxSliderModule } from 'igniteui-angular';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SliderModule } from 'src/app/shared/components/slider/slider.module';

@NgModule({
  imports: [
    CommonModule,
    PizzaRoutes,
    BrowserModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    FormsModule,
    IgxInputGroupModule,
    IgxSliderModule,
    SliderModule
  ],
  declarations: [
    PizzaComponent
  ]
})
export class PizzaModule { }
