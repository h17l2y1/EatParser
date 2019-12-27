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
    if (set.restaurantId === 1) {
      return 'card-heared mafia';
    }
    if (set.restaurantId === 2) {
      return 'card-heared yaposhka';
    }
    if (set.restaurantId === 3) {
      return 'card-heared sushiPapa';
    }
    if (set.restaurantId === 4) {
      return 'card-heared rollClub';
    }
    return 'card-heared';
  }

  private getAllSets() {
    this.setService.getAll().subscribe(response => {
      this.response = _.cloneDeep(response);
      this.setPriceRange(response.sets);
      this.setView = response.sets;
      this.initRestaurauntDropDown();
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

  public filter(): void {
    if (!this.text && !this.priceRange) {
      if (this.restDropDownForm.controls.restaurauntList.value.id === 0) {
        this.setView = _.cloneDeep(this.response.sets);
        return;
      }
      this.setView = this.response.sets.filter(rol => rol.restaurantId === this.restDropDownForm.controls.restaurauntList.value.id);
      return;
    }

    if (this.text && !this.priceRange) {
      if (this.restDropDownForm.controls.restaurauntList.value.id === 0) {
        this.setView = this.response.sets.filter(rol => rol.name.toLowerCase().includes(this.text.toLowerCase()));
        return;
      }
      this.setView = this.response.sets.filter(rol => rol.name.toLowerCase().includes(this.text.toLowerCase())
        && rol.restaurantId === this.restDropDownForm.controls.restaurauntList.value.id);
      return;
    }

    if (this.priceRange && !this.text) {
      if (this.restDropDownForm.controls.restaurauntList.value.id === 0) {
        this.setView = this.response.sets.filter(rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper);
        return;
      }
      this.setView = this.response.sets.filter(rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper
        && rol.restaurantId === this.restDropDownForm.controls.restaurauntList.value.id);
      return;
    }

    if (this.restDropDownForm.controls.restaurauntList.value.id === 0) {
      this.setView = this.response.sets.filter(
        rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper &&
        rol.name.toLowerCase().includes(this.text.toLowerCase()));
      return;
    }

    this.setView = this.response.sets.filter(
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
    this.setView = _.orderBy(this.setView, [param, 'weight'], [type]);
  }

  private initSortDropDown(): void {
    this.sortDropDown = [['price', 'desc'], ['price', 'asc'], ['count', 'desc'], ['count', 'asc']];

    this.sortDropDownForm = new FormGroup({
      sortList: new FormControl(this.sortDropDown[0]),
    });
  }

  private initRestaurauntDropDown(): void {
    this.getRestauraunts(this.response.sets);

    this.restDropDownForm = new FormGroup({
      restaurauntList: new FormControl(this.typeDropDown[0]),
    });
  }

  private getRestauraunts(sets: SetsViewItem[]): void {
    this.typeDropDown = new Array<Resrauraunt>();
    const mappedArray = sets.map(x => x.restaurantId);
    const typesArray = mappedArray.filter((n, i) => mappedArray.indexOf(n) === i);

    for (let i = 0; i < typesArray.length + 1; i++) {
      this.typeDropDown.push(new Resrauraunt(i, RestaurantType[i]));
    }

  }

}


