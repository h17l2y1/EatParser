import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;

  constructor(private router: Router) { }

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
    const aaa = this.loginForm.controls.login.value;
    const bbb = this.loginForm.controls.password.value;
  }

}
