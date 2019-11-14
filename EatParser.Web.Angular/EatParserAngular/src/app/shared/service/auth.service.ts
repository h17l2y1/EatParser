import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtResponseView } from '../model/account/jwt-response.view';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router/*, public jwtHelper: JwtHelperService*/) {
  }

  public setJwt(data: JwtResponseView): void {
    localStorage.setItem('accessToken', data.accessToken);
    localStorage.setItem('refreshToken', data.refreshToken);
  }

  public removeJwt(): void {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');
    this.router.navigate(['/login']);
  }

  // public isAuthenticated(): boolean {
  //   const token = localStorage.getItem('accessToken');
  //   return !this.jwtHelper.isTokenExpired(token);
  // }

  //   public refreshToken(model: RefreshTokenViewModel): Observable<null> {
  //   return this.http.post<null>(this.rootUrl + `/Auth/RefreshToken`, model);
  // }

  //   public getToken(model: GenerateTokenViewModel): Observable<JwtResponseViewModel> {
  //   return this.http.post<JwtResponseViewModel>(this.rootUrl + `/Auth/Token`, model);
  // }

}
