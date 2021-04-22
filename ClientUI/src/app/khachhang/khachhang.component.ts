import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../services/base.component';

@Component({
  selector: 'app-khachhang',
  templateUrl: './khachhang.component.html',
  styleUrls: ['./khachhang.component.css']
})
export class KhachhangComponent  extends BaseComponent implements OnInit {
  acc:any;
    constructor(injector:Injector) {
      super(injector);
    }
  
    ngOnInit(): void {
      this.taiKhoan();
      this.loadScripts();
      
      
    }
    taiKhoan(){
      this._login.items.subscribe((res) => {
        this.acc = res;
      });
    }
  }
  