import { Component, OnInit } from '@angular/core';
import { SliderType } from 'igniteui-angular';
import { PriceRange } from '../../model/set/price-range.model';
import { SliderService } from '../../service/slider.service';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css']
})
export class SliderComponent implements OnInit {

  public sliderType = SliderType;
  public minValue: number;
  public maxValue: number;

  public inputPriceRange: PriceRange;

  constructor(private sliderService: SliderService) {
  }

  ngOnInit() {
    this.minValue = this.sliderService.minValue;
    this.maxValue = this.sliderService.maxValue;
    this.inputPriceRange = new PriceRange(this.minValue,  this.maxValue);
  }

  public updatePriceRange(event): void {
    const priceRange = this.inputPriceRange;
    switch (event.id) {
      case 'lowerInput': {
        if (!isNaN(parseInt(event.value, 10))) {
          this.inputPriceRange = new PriceRange(parseInt(event.value, 10), priceRange.upper);
          this.sliderService.sendRange(this.inputPriceRange);
        }
        break;
      }
      case 'upperInput': {
        if (!isNaN(parseInt(event.value, 10))) {
          this.inputPriceRange = new PriceRange(priceRange.lower, parseInt(event.value, 10));
          this.sliderService.sendRange(this.inputPriceRange);
        }
        break;
      }
    }
  }

  public OnChange(event: PriceRange): void {
    this.sliderService.sendRange(event);
  }

}

