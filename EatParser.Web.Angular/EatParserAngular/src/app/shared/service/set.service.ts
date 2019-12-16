import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RolsView } from '../model/rol/rols.view';

@Injectable({
  providedIn: 'root'
})
export class SetService {

  readonly rootUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getAll(): Observable<RolsView> {
    return this.http.get<RolsView>(this.rootUrl + 'Set/GetAll');
  }

}
