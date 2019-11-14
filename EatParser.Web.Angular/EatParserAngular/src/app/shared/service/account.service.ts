import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SignUpView } from '../model/account/sign-up.view';
import { JwtResponseView } from '../model/account/jwt-response.view';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private apiControllerURL = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public signUp(model: SignUpView): Observable<JwtResponseView> {
    return this.http.post<JwtResponseView>(this.apiControllerURL + `Account/SignUp`, model);
  }

  public login(model: SignUpView): Observable<JwtResponseView> {
    return this.http.post<JwtResponseView>(this.apiControllerURL + `Account/Login`, model);
  }

}
