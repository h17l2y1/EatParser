import { Component, OnInit, OnDestroy } from '@angular/core';
import * as _ from 'lodash';
import { SushiView, SushiViewItem } from 'src/app/shared/model/sushi/sushi.view';
import { Subscription } from 'rxjs';
import { PriceRange } from 'src/app/shared/model/set/price-range.model';
import { FormGroup, FormControl } from '@angular/forms';
import { Resrauraunt } from 'src/app/shared/model/restauraunt-model';
import { SliderService } from 'src/app/shared/service/slider.service';
import { RestaurantType } from 'src/app/shared/model/restauraunt-type';
import { SushiService } from 'src/app/shared/service/sushi.service';

@Component({
  selector: 'app-sushi',
  templateUrl: './sushi.component.html',
  styleUrls: ['./sushi.component.scss']
})
export class SushiComponent implements OnInit, OnDestroy {


  public response: SushiView;
  public sushiView: SushiViewItem[];
  public subscription: Subscription;
  public priceRange: PriceRange;
  public text: string;
  public restDropDownForm: FormGroup;
  public sortDropDownForm: FormGroup;

  public typeDropDown: Resrauraunt[];
  public sortDropDown: Array<Array<string>>;

  constructor(private sushiService: SushiService, private sliderService: SliderService) {
    this.subscription = sliderService.getRange().subscribe(priceRange => {
      this.priceRange = priceRange;
      this.multiFilter();
    });
  }

  ngOnInit() {
    this.initSortDropDown();
    this.getAllpizzas();
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  private getAllpizzas() {
    this.sushiService.getAll().subscribe(response => {
      this.response = _.cloneDeep(response);
      this.setPriceRange(response.sushi);
      this.sushiView = response.sushi;
      this.initRestaurauntDropDown();
      this.multiFilter();
    });
  }

  private setPriceRange(sushi: SushiViewItem[]): void {
    this.sliderService.maxValue = Math.max.apply(Math, sushi.map(x => x.price));
    this.sliderService.minValue = Math.min.apply(Math, sushi.map(x => x.price));
  }

  public setText(text: string): void {
    this.text = text;
    this.multiFilter();
  }

  public filter(): void {
    if (!this.text && !this.priceRange) {
      if (this.restDropDownForm.controls.restaurauntList.value.id === 0) {
        this.sushiView = _.cloneDeep(this.response.sushi);
        return;
      }
      this.sushiView = this.response.sushi.filter(rol => rol.restaurantId === this.restDropDownForm.controls.restaurauntList.value.id);
      return;
    }

    if (this.text && !this.priceRange) {
      if (this.restDropDownForm.controls.restaurauntList.value.id === 0) {
        this.sushiView = this.response.sushi.filter(rol => rol.name.toLowerCase().includes(this.text.toLowerCase()));
        return;
      }
      this.sushiView = this.response.sushi.filter(rol => rol.name.toLowerCase().includes(this.text.toLowerCase())
        && rol.restaurantId === this.restDropDownForm.controls.restaurauntList.value.id);
      return;
    }

    if (this.priceRange && !this.text) {
      if (this.restDropDownForm.controls.restaurauntList.value.id === 0) {
        this.sushiView = this.response.sushi.filter(rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper);
        return;
      }
      this.sushiView = this.response.sushi.filter(rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper
        && rol.restaurantId === this.restDropDownForm.controls.restaurauntList.value.id);
      return;
    }

    if (this.restDropDownForm.controls.restaurauntList.value.id === 0) {
      this.sushiView = this.response.sushi.filter(
        rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper &&
        rol.name.toLowerCase().includes(this.text.toLowerCase()));
      return;
    }

    this.sushiView = this.response.sushi.filter(
      rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper &&
      rol.name.toLowerCase().includes(this.text.toLowerCase()) &&
      rol.restaurantId === this.restDropDownForm.controls.restaurauntList.value.id
    );
  }

  private multiFilter(): void {
    this.filter();
    this.sort();
  }

  public sort(): void {
    const param = this.sortDropDownForm.controls.sortList.value[0];
    const type = this.sortDropDownForm.controls.sortList.value[1];
    this.sushiView = _.orderBy(this.sushiView, [param, 'weight'], [type]);
  }

  private initSortDropDown(): void {
    this.sortDropDown = [['price', 'desc'], ['price', 'asc'], ['count', 'desc'], ['count', 'asc']];

    this.sortDropDownForm = new FormGroup({
      sortList: new FormControl(this.sortDropDown[0]),
    });
  }

  private initRestaurauntDropDown(): void {
    this.getRestauraunts(this.response.sushi);

    this.restDropDownForm = new FormGroup({
      restaurauntList: new FormControl(this.typeDropDown[0]),
    });
  }

  private getRestauraunts(pizzas: SushiViewItem[]): void {
    this.typeDropDown = new Array<Resrauraunt>();
    const mappedArray = pizzas.map(x => x.restaurantId);
    const typesArray = mappedArray.filter((n, i) => mappedArray.indexOf(n) === i);

    for (let i = 0; i < typesArray.length + 1; i++) {
      this.typeDropDown.push(new Resrauraunt(i, RestaurantType[i]));
    }

  }

}
