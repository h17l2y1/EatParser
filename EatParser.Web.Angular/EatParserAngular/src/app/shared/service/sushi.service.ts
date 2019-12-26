import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SushiView } from '../model/sushi/sushi.view';

@Injectable({
  providedIn: 'root'
})
export class SushiService {

  readonly rootUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getAll(): Observable<SushiView> {
    return this.http.get<SushiView>(this.rootUrl + 'Sushi/GetAll');
  }

}
