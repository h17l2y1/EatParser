import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SushiComponent } from './sushi.component';
import { SushiRoutes } from './sushi.routing';
import { IgxInputGroupModule, IgxSliderModule } from 'igniteui-angular';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SliderModule } from 'src/app/shared/components/slider/slider.module';

@NgModule({
  imports: [
    CommonModule,
    SushiRoutes,
    BrowserModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    FormsModule,
    IgxInputGroupModule,
    IgxSliderModule,
    SliderModule
  ],
  declarations: [
    SushiComponent,
  ]
})
export class SushiModule { }
