import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SignUpView } from '../model/account/sign-up.view';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private apiControllerURL = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public signUp(model: SignUpView): Observable<null> {
    return this.http.post<null>(this.apiControllerURL + `Account/SignUp`, model);
  }

  public login(model: SignUpView): Observable<any> {
    return this.http.post<any>(this.apiControllerURL + `Account/Login`, model);
  }

}
