import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { SignUpView } from 'src/app/shared/model/account/sign-up.view';
import { AccountService } from 'src/app/shared/service/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;
  public signUpModel: SignUpView;

  constructor(private router: Router, private accountService: AccountService) { }

  ngOnInit() {
    this.initLoginForm();
  }

  private initLoginForm(): void {
    this.loginForm = new FormGroup({
      login: new FormControl(''),
      password: new FormControl(''),
    });
  }

  public getLoginData(): void {
    const loginModel = new SignUpView();
    loginModel.login = this.loginForm.controls.login.value;
    loginModel.password = this.loginForm.controls.password.value;
    this.accountService.login(loginModel).subscribe(response => {
      const a = response;
    });
  }

  public getSignUpData(): void {
    const signUpModel = new SignUpView();
    signUpModel.login = this.loginForm.controls.login.value;
    signUpModel.password = this.loginForm.controls.password.value;
    this.accountService.signUp(signUpModel).subscribe(response => {
      const a = response;
    });
  }

}
