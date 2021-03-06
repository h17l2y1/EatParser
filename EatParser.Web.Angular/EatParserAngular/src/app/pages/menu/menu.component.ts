import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  public redirect(page: string): void {
    if (page === 'sets') {
      this.router.navigate(['/sets']);
      return;
    }
    if (page === 'rols') {
      this.router.navigate(['/rols']);
      return;
    }
    if (page === 'sushi') {
      this.router.navigate(['/sushi']);
      return;
    }
    if (page === 'pizza') {
      this.router.navigate(['/pizza']);
      return;
    }
  }


}
