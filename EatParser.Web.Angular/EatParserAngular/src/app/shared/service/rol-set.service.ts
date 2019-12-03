import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AllRolSetView } from '../model/rol/get-all-rol-set.view';

@Injectable({
  providedIn: 'root'
})
export class RolSetService {

  readonly rootUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getAllRolSet(): Observable<AllRolSetView>{
    return this.http.get<AllRolSetView>(this.rootUrl + 'Rol/GetAll');
  }

  public getMafiaRolSet(): Observable<AllRolSetView>{
    return this.http.get<AllRolSetView>(this.rootUrl + 'Rol/GetMafia');
  }

  public getYaposhkaRolSet(): Observable<AllRolSetView>{
    return this.http.get<AllRolSetView>(this.rootUrl + 'Rol/GetYaposhka');
  }

}
