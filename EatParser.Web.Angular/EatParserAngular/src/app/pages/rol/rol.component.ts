import { Component, OnInit } from '@angular/core';
import { RolService } from 'src/app/shared/service/rol.service';
import { RolsView, RolsViewItem } from 'src/app/shared/model/rol/rols.view';
import * as _ from 'lodash';

@Component({
  selector: 'app-rol',
  templateUrl: './rol.component.html',
  styleUrls: ['./rol.component.css']
})
export class RolComponent implements OnInit {

  public response: RolsView;
  public rolsView: RolsViewItem[];

  constructor(private rolService: RolService) { }

  ngOnInit() {
    this.getAllRols();
  }

  private getAllRols() {
    this.rolService.getAll().subscribe(response => {
      this.response = _.cloneDeep(response);
    });
  }


}
