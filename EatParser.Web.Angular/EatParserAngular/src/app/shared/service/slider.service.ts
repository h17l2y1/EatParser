import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { PriceRange } from '../model/set/price-range.model';

@Injectable({
  providedIn: 'root'
})
export class SliderService {

  public minValue: number;
  public maxValue: number;
  public subject = new Subject<PriceRange>();

  constructor() { }

  public sendRange(object: PriceRange): void {
    this.subject.next(object);
  }

  public getRange(): Observable<PriceRange> {
    return this.subject.asObservable();
  }

  public complete(): void {
    this.subject.complete();
  }
}
