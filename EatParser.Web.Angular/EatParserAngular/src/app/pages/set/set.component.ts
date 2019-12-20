import { Component, OnInit, OnDestroy } from '@angular/core';
import { SetService } from 'src/app/shared/service/set.service';
import { RolsView, RolsViewItem } from 'src/app/shared/model/rol/rols.view';
import * as _ from 'lodash';
import { PriceRange } from 'src/app/shared/model/set/price-range.model';
import { Subscription } from 'rxjs';
import { SliderService } from 'src/app/shared/service/slider.service';
import { RestaurantType } from 'src/app/shared/model/restauraunt-type';
import { FormGroup, FormControl } from '@angular/forms';

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
  public dropDownForm: FormGroup;

  public leaveDropDown = [
    { id: 0, name: 'Not selected' },
    { id: 1, name: 'Sick' },
    { id: 2, name: 'Day off' },
    { id: 3, name: 'Vacation' }
  ];

  constructor(private setService: SetService, private sliderService: SliderService) {
    this.subscription = sliderService.getRange()
    .subscribe(priceRange => {
      this.priceRange = priceRange;
      this.multiFilter();
    });
  }

  ngOnInit() {
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
      this.multiFilter();
      this.dropDown();
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
      this.rolsView = _.cloneDeep(this.response.rols);
      return;
    }
    if (this.text && !this.priceRange) {
      this.rolsView = this.response.rols.filter(rol => rol.name.toLowerCase().includes(this.text.toLowerCase()));
      return;
    }
    if (this.priceRange && !this.text) {
      this.rolsView = this.response.rols.filter(rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper);
      return;
    }
    this.rolsView = this.response.rols.filter(
      rol => rol.price > this.priceRange.lower && rol.price < this.priceRange.upper &&
      rol.name.toLowerCase().includes(this.text.toLowerCase())
    );
  }

  public sort(): void {
    // this.rolsView = _.sort(this.response.rols);
    this.rolsView = _.orderBy(this.rolsView, ['price', 'weight'], ['desc']);

  }

  private dropDown(): void {
    this.dropDownForm = new FormGroup({
      leaveList: new FormControl(this.leaveDropDown[0]),
    });

    const bbb = _.groupBy(this.response.rols, 'restaurantId');

    const aaa = this.rolsView.filter(x => x.restaurantId === RestaurantType.Mafia);
  }

}


