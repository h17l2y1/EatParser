import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  constructor(private router: Router) {
    console.log('Sidebar constructor called');
  }
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
