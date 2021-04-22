import { Component, OnInit,NgModule, Injector } from '@angular/core';
import { BaseComponent } from 'src/app/services/base.component';

@Component({
  selector: 'app-danhsach',
  templateUrl: './danhsach.component.html',
  styleUrls: ['./danhsach.component.css']
})
export class DanhsachComponent extends BaseComponent implements OnInit {

  constructor(
    injector:Injector
  ) {super(injector) }
breadcrum="shop";
  ngOnInit(): void {
    setTimeout(() => {
      this.loadScripts();
    },);
  }

}
