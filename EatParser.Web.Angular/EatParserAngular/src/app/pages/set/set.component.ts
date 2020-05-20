import { Component, OnInit, OnDestroy } from '@angular/core';
import { SetService } from 'src/app/shared/service/set.service';
import * as _ from 'lodash';
import { PriceRange } from 'src/app/shared/model/set/price-range.model';
import { Subscription } from 'rxjs';
import { SliderService } from 'src/app/shared/service/slider.service';
import { RestaurantType } from 'src/app/shared/model/restauraunt-type';
import { FormGroup, FormControl } from '@angular/forms';
import { Resrauraunt } from 'src/app/shared/model/restauraunt-model';
import { SetsView, SetsViewItem } from 'src/app/shared/model/set/sets-view';

@Component({
  selector: 'app-set',
  templateUrl: './set.component.html',
  styleUrls: ['./set.component.scss']
})
export class SetComponent implements OnInit, OnDestroy {

  public response: SetsView;
  public setView: SetsViewItem[];
  public subscription: Subscription;
  public priceRange: PriceRange;
  public text: string;
  public restDropDownForm: FormGroup;
  public sortDropDownForm: FormGroup;

  public typeDropDown: Resrauraunt[];
  public sortDropDown: Array<Array<string>>;

  public yaposhkaClass = 'card-heared yaposhka';
  public mafiaClass = 'card-heared mafia';

  public isYaposhka = false;
  public isMafia = true;
  public rest: Resrauraunt;



  constructor(private setService: SetService, private sliderService: SliderService) {
    this.subscription = sliderService.getRange().subscribe(priceRange => {
      this.priceRange = priceRange;
      this.multiFilter();
    });
  }

  ngOnInit() {
    this.initSortDropDown();
    this.getAllSets();
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public getClass(set: SetsViewItem): string {
    if (set.restaurantId === 'e852dc88-be1c-4c75-829b-087b492c3e35') {
      return 'card-header mafia';
    }
    if (set.restaurantId === '461881d3-a45d-48a8-b70f-2c6bbedc9d69') {
      return 'card-header yaposhka';
    }
    if (set.restaurantId === '097d5c06-dcae-4fb0-b7c5-5bee485ae601') {
      return 'card-header sushiPapa';
    }
    if (set.restaurantId === 'c27bfca8-afb6-4e89-aca4-3cefb2ac0307') {
      return 'card-header rollClub';
    }
    return 'card-header';
  }

  private getAllSets() {
    this.setService.getAll().subscribe(response => {
      this.response = _.cloneDeep(response);
      this.setPriceRange(response.sets);
      this.setView = response.sets;
      this.initRestaurantDropDown();
      this.multiFilter();
    });
  }

  private setPriceRange(sets: SetsViewItem[]): void {
    this.sliderService.maxValue = Math.max.apply(Math, sets.map(x => x.price));
    this.sliderService.minValue = Math.min.apply(Math, sets.map(x => x.price));
  }

  public setText(text: string): void {
    this.text = text;
    this.multiFilter();
  }

  public multiFilter(): void {
    this.filter();
    this.sort();
  }

  public filter(): void {
    if (!this.text && !this.priceRange) {
      if (!this.restDropDownForm.controls.restaurantList.value.id) {
        this.setView = _.cloneDeep(this.response.sets);
        return;
      }
      this.setView = this.response.sets.filter(rol => rol.restaurantId === this.restDropDownForm.controls.restaurantList.value.id);
      return;
    }

    if (this.text && !this.priceRange) {
      if (!this.restDropDownForm.controls.restaurantList.value.id) {
        this.setView = this.response.sets.filter(rol => rol.name.toLowerCase().includes(this.text.toLowerCase()));
        return;
      }
      this.setView = this.response.sets.filter(rol => rol.name.toLowerCase().includes(this.text.toLowerCase())
        && rol.restaurantId === this.restDropDownForm.controls.restaurantList.value.id);
      return;
    }

    if (this.priceRange && !this.text) {
      if (!this.restDropDownForm.controls.restaurantList.value.id) {
        this.setView = this.response.sets.filter(rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper);
        return;
      }
      this.setView = this.response.sets.filter(rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper
        && rol.restaurantId === this.restDropDownForm.controls.restaurantList.value.id);
      return;
    }

    if (!this.restDropDownForm.controls.restaurantList.value.id) {
      this.setView = this.response.sets.filter(
        rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper &&
        rol.name.toLowerCase().includes(this.text.toLowerCase()));
      return;
    }

    this.setView = this.response.sets.filter(
      rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper &&
      rol.name.toLowerCase().includes(this.text.toLowerCase()) &&
      rol.restaurantId === this.restDropDownForm.controls.restaurantList.value.id
    );
  }

  public sort(): void {
    const param = this.sortDropDownForm.controls.sortList.value[0];
    const type = this.sortDropDownForm.controls.sortList.value[1];
    this.setView = _.orderBy(this.setView, [param, 'weight'], [type]);
  }

  private initSortDropDown(): void {
    this.sortDropDown = [['price', 'desc'], ['price', 'asc'], ['count', 'desc'], ['count', 'asc']];
    //this.sortDropDown = [['Цена', 'по позрастанию'], ['Цена', 'по убыванию'], ['Кол-во', 'по позрастанию'], ['Кол-во', 'по убыванию']];

    this.sortDropDownForm = new FormGroup({
      sortList: new FormControl(this.sortDropDown[0]),
    });
  }

  private initRestaurantDropDown(): void {
    this.getRestaurants(this.response.sets);

    this.restDropDownForm = new FormGroup({
      restaurantList: new FormControl(this.typeDropDown[0]),
    });
  }

  private getRestaurants(sets: SetsViewItem[]): void {
    this.typeDropDown = new Array<Resrauraunt>();
    const mappedArray = sets.map(x => x.restaurantId);
    const uniqueResraurauntId = mappedArray.filter((n, i) => mappedArray.indexOf(n) === i);

    this.typeDropDown.push(new Resrauraunt(undefined, RestaurantType[0]));
    for (let i = 0; i < uniqueResraurauntId.length; i++) {
      this.typeDropDown.push(new Resrauraunt(uniqueResraurauntId[i], RestaurantType[i + 1]));
    }

  }

}


