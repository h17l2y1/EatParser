import { Component, OnInit } from '@angular/core';
import { RolService } from 'src/app/shared/service/rol.service';
import { RolsView } from 'src/app/shared/model/rol/rols.view';

@Component({
  selector: 'app-rol',
  templateUrl: './rol.component.html',
  styleUrls: ['./rol.component.css']
})
export class RolComponent implements OnInit {

  public rolsView: RolsView;

  constructor(private rolService: RolService) { }

  ngOnInit() {
    this.getAllRols();
  }

  private getAllRols() {
    this.rolService.getAll().subscribe(response => {
      this.rolsView = response;
    });
  }

}
