import { Component, OnInit, OnDestroy } from '@angular/core';
import { SetService } from 'src/app/shared/service/set.service';
import { RolsView, RolsViewItem } from 'src/app/shared/model/rol/rols.view';
import * as _ from 'lodash';
import { PriceRange } from 'src/app/shared/model/set/price-range.model';
import { Subscription } from 'rxjs';
import { SliderService } from 'src/app/shared/service/slider.service';
import { RestaurantType } from 'src/app/shared/model/restauraunt-type';
import { FormGroup, FormControl } from '@angular/forms';
import { Resrauraunt } from 'src/app/shared/model/restauraunt-model';

@Component({
  selector: 'app-set',
  templateUrl: './set.component.html',
  styleUrls: ['./set.component.scss']
})
export class SetComponent implements OnInit, OnDestroy {

  public response: RolsView;
  public rolsView: RolsViewItem[];
  public subscription: Subscription;
  public priceRange: PriceRange;
  public text: string;
  public restDropDownForm: FormGroup;
  public sortDropDownForm: FormGroup;

  public typeDropDown: Resrauraunt[];
  public sortDropDown: Array<Array<string>>;

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

  private getAllSets() {
    this.setService.getAll().subscribe(response => {
      this.response = _.cloneDeep(response);
      this.setPriceRange(response.rols);
      this.rolsView = response.rols;
      this.initRestaurauntDropDown();
      this.multiFilter();
    });
  }

  private setPriceRange(rols: RolsViewItem[]): void {
    this.sliderService.maxValue = Math.max.apply(Math, rols.map(x => x.price));
    this.sliderService.minValue = Math.min.apply(Math, rols.map(x => x.price));
  }

  public setText(text: string): void {
    this.text = text;
    this.multiFilter();
  }

  public multiFilter(): void {
    if (!this.text && !this.priceRange) {
      if (this.restDropDownForm.controls.restaurauntList.value.id === 0) {
        this.rolsView = _.cloneDeep(this.response.rols);
        this.sort();
        return;
      }
      this.rolsView = this.response.rols.filter(rol => rol.restaurantId === this.restDropDownForm.controls.restaurauntList.value.id);
      this.sort();
      return;
    }

    if (this.text && !this.priceRange) {
      if (this.restDropDownForm.controls.restaurauntList.value.id === 0) {
        this.rolsView = this.response.rols.filter(rol => rol.name.toLowerCase().includes(this.text.toLowerCase()));
        this.sort();
        return;
      }
      this.rolsView = this.response.rols.filter(rol => rol.name.toLowerCase().includes(this.text.toLowerCase())
        && rol.restaurantId === this.restDropDownForm.controls.restaurauntList.value.id);
      this.sort();
      return;
    }

    if (this.priceRange && !this.text) {
      if (this.restDropDownForm.controls.restaurauntList.value.id === 0) {
        this.rolsView = this.response.rols.filter(rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper);
        this.sort();
        return;
      }
      this.rolsView = this.response.rols.filter(rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper
        && rol.restaurantId === this.restDropDownForm.controls.restaurauntList.value.id);
      this.sort();
      return;
    }

    this.rolsView = this.response.rols.filter(
      rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper &&
      rol.name.toLowerCase().includes(this.text.toLowerCase()) &&
      rol.restaurantId === this.restDropDownForm.controls.restaurauntList.value.id
    );
    this.sort();
  }

  public sort(): void {
    const param = this.sortDropDownForm.controls.sortList.value[0];
    const type = this.sortDropDownForm.controls.sortList.value[1];
    this.rolsView = _.orderBy(this.rolsView, [param, 'weight'], [type]);
  }

  private initSortDropDown(): void {
    this.sortDropDown = [['price', 'desc'], ['price', 'asc'], ['count', 'desc'], ['count', 'asc']];

    this.sortDropDownForm = new FormGroup({
      sortList: new FormControl(this.sortDropDown[0]),
    });
  }

  private initRestaurauntDropDown(): void {
    this.getRestauraunts(this.response.rols);

    this.restDropDownForm = new FormGroup({
      restaurauntList: new FormControl(this.typeDropDown[0]),
    });
  }

  private getRestauraunts(rols: RolsViewItem[]): void {
    this.typeDropDown = new Array<Resrauraunt>();
    const mappedArray = rols.map(x => x.restaurantId);
    const typesArray = mappedArray.filter((n, i) => mappedArray.indexOf(n) === i);

    for (let i = 0; i < typesArray.length + 1; i++) {
      this.typeDropDown.push(new Resrauraunt(i, RestaurantType[i]));
    }

  }

}


