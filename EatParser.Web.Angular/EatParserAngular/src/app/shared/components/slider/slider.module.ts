import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IgxInputGroupModule, IgxSliderModule } from 'igniteui-angular';
import { SliderComponent } from 'src/app/shared/components/slider/slider.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    SliderComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    FormsModule,
    IgxInputGroupModule,
    IgxSliderModule
  ],
  exports: [
    SliderComponent
  ]
})
export class SliderModule { }
