import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SetsView } from '../model/set/sets-view';

@Injectable({
  providedIn: 'root'
})
export class SetService {

  readonly rootUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getAll(): Observable<SetsView> {
    return this.http.get<SetsView>(this.rootUrl + 'Set/GetAll');
  }

}
