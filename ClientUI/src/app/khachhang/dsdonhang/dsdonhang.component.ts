import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/services/base.component';
import { KhachhangComponent } from '../khachhang.component';

@Component({
  selector: 'app-dsdonhang',
  templateUrl: './dsdonhang.component.html',
  styleUrls: ['./dsdonhang.component.css']
})
export class DsdonhangComponent extends BaseComponent implements OnInit {

  dhsbykh: any; index: any; size: any; khach: any;
  dsdonhang: any;
  response: any;
  totalItems: any;
  constructor(injector: Injector) {
    super(injector);
  }
  // /api/qldonhang/get-by-kh
  ngOnInit(): void {
    document.title = "Đơn hàng của tôi";
    this.index = 1; this.size = 12;
    this._login.items.subscribe((res) => {
      this.khach = res;


    });

    this.getDonHangByKhachHang();

  }
  taiKhoan() {
    this._login.items.subscribe((res) => {
      this.khach = res;

    });
  }
  getDonHangByKhachHang() {
    this._api.get('api/QLDonHang/get-by-kh/' + this.khach[0].maKhachHang + '/' + 1 + '/' + 10).takeUntil(this.unsubscribe).subscribe(dau => {
      this.response = dau;
      this.dsdonhang = this.response.data;
      this.totalItems = this.response.totalItems;
    });
  }
  huyDon(madon){
   
    if(confirm("bạn có muốn hủy đơn?")){
    this._api.get('api/QLDonHang/cancel/'+madon).takeUntil(this.unsubscribe).subscribe(res => {
 
      this.loadPage(1);
      alert("đơn hàng "+madon+" đã bị hủy.")
    }, err => { });
  }
  }
  loadPage(page) {
    this._api.get('api/QLDonHang/get-by-kh/' + this.khach[0].maKhachHang + '/' + page + '/' + 10).takeUntil(this.unsubscribe).subscribe(dau => {
      this.response = dau;
      this.dsdonhang = this.response.data;
      this.totalItems = this.response.totalItems;
    });
  }

}
