import { Component, OnInit, OnDestroy } from '@angular/core';
import * as _ from 'lodash';
import { Subscription } from 'rxjs';
import { PriceRange } from 'src/app/shared/model/set/price-range.model';
import { FormGroup, FormControl } from '@angular/forms';
import { Resrauraunt } from 'src/app/shared/model/restauraunt-model';
import { SliderService } from 'src/app/shared/service/slider.service';
import { RestaurantType } from 'src/app/shared/model/restauraunt-type';
import { PizzaView, PizzaViewItem } from 'src/app/shared/model/pizza/pizza.view';
import { PizzaService } from 'src/app/shared/service/pizza.service';

@Component({
  selector: 'app-pizza',
  templateUrl: './pizza.component.html',
  styleUrls: ['./pizza.component.scss']
})
export class PizzaComponent implements OnInit, OnDestroy {


  public response: PizzaView;
  public pizzaView: PizzaViewItem[];
  public subscription: Subscription;
  public priceRange: PriceRange;
  public text: string;
  public restDropDownForm: FormGroup;
  public sortDropDownForm: FormGroup;

  public typeDropDown: Resrauraunt[];
  public sortDropDown: Array<Array<string>>;

  constructor(private pizzaService: PizzaService, private sliderService: SliderService) {
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
    this.pizzaService.getAll().subscribe(response => {
      this.response = _.cloneDeep(response);
      this.setPriceRange(response.pizzas);
      this.pizzaView = response.pizzas;
      this.initRestaurauntDropDown();
      this.multiFilter();
    });
  }

  private setPriceRange(pizzas: PizzaViewItem[]): void {
    this.sliderService.maxValue = Math.max.apply(Math, pizzas.map(x => x.price));
    this.sliderService.minValue = Math.min.apply(Math, pizzas.map(x => x.price));
  }

  public setText(text: string): void {
    this.text = text;
    this.multiFilter();
  }

  public filter(): void {
    if (!this.text && !this.priceRange) {
      if (this.restDropDownForm.controls.restaurantList.value.id === 0) {
        this.pizzaView = _.cloneDeep(this.response.pizzas);
        return;
      }
      this.pizzaView = this.response.pizzas.filter(rol => rol.restaurantId === this.restDropDownForm.controls.restaurantList.value.id);
      return;
    }

    if (this.text && !this.priceRange) {
      if (this.restDropDownForm.controls.restaurantList.value.id === 0) {
        this.pizzaView = this.response.pizzas.filter(rol => rol.name.toLowerCase().includes(this.text.toLowerCase()));
        return;
      }
      this.pizzaView = this.response.pizzas.filter(rol => rol.name.toLowerCase().includes(this.text.toLowerCase())
        && rol.restaurantId === this.restDropDownForm.controls.restaurantList.value.id);
      return;
    }

    if (this.priceRange && !this.text) {
      if (this.restDropDownForm.controls.restaurantList.value.id === 0) {
        this.pizzaView = this.response.pizzas.filter(rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper);
        return;
      }
      this.pizzaView = this.response.pizzas.filter(rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper
        && rol.restaurantId === this.restDropDownForm.controls.restaurantList.value.id);
      return;
    }

    if (this.restDropDownForm.controls.restaurantList.value.id === 0) {
      this.pizzaView = this.response.pizzas.filter(
        rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper &&
        rol.name.toLowerCase().includes(this.text.toLowerCase()));
      return;
    }

    this.pizzaView = this.response.pizzas.filter(
      rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper &&
      rol.name.toLowerCase().includes(this.text.toLowerCase()) &&
      rol.restaurantId === this.restDropDownForm.controls.restaurantList.value.id
    );
  }

  private multiFilter(): void {
    this.filter();
    this.sort();
  }

  public sort(): void {
    const param = this.sortDropDownForm.controls.sortList.value[0];
    const type = this.sortDropDownForm.controls.sortList.value[1];
    this.pizzaView = _.orderBy(this.pizzaView, [param, 'weight'], [type]);
  }

  private initSortDropDown(): void {
    this.sortDropDown = [['price', 'desc'], ['price', 'asc'], ['count', 'desc'], ['count', 'asc']];

    this.sortDropDownForm = new FormGroup({
      sortList: new FormControl(this.sortDropDown[0]),
    });
  }

  private initRestaurauntDropDown(): void {
    this.getRestauraunts(this.response.pizzas);

    this.restDropDownForm = new FormGroup({
      restaurantList: new FormControl(this.typeDropDown[0]),
    });
  }

  private getRestauraunts(pizzas: PizzaViewItem[]): void {
    this.typeDropDown = new Array<Resrauraunt>();
    const mappedArray = pizzas.map(x => x.restaurantId);
    const typesArray = mappedArray.filter((n, i) => mappedArray.indexOf(n) === i);

    for (let i = 0; i < typesArray.length + 1; i++) {
      this.typeDropDown.push(new Resrauraunt(i, RestaurantType[i]));
    }

  }

}
