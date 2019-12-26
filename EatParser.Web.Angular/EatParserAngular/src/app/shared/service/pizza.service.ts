import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PizzaView } from '../model/pizza/pizza.view';

@Injectable({
  providedIn: 'root'
})
export class PizzaService {

  readonly rootUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getAll(): Observable<PizzaView> {
    return this.http.get<PizzaView>(this.rootUrl + 'Pizza/GetAll');
  }

}
