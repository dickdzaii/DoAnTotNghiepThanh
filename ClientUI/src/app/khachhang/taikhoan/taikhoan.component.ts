import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/services/base.component';
import { KhachhangComponent } from '../khachhang.component';

@Component({
  selector: 'app-taikhoan',
  templateUrl: './taikhoan.component.html',
  styleUrls: ['./taikhoan.component.css']
})
export class TaikhoanComponent extends BaseComponent implements OnInit {
tg:any;
  constructor(private khach:KhachhangComponent,injector:Injector) {
    
    super(injector);
  }

  ngOnInit(): void {
   
    this.taiKhoan();
   
    this.loadScripts();
  }
  taiKhoan(){
    this._login.items.subscribe((res) => {
      this.khach.acc = res;
     this.tg=this.khach.acc[0];
     document.title="Profile của tôi";
    });
  }
}
