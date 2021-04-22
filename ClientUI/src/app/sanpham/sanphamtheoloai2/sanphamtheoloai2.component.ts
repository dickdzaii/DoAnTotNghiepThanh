import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/services/base.component';

@Component({
  selector: 'app-sanphamtheoloai2',
  templateUrl: './sanphamtheoloai2.component.html',
  styleUrls: ['./sanphamtheoloai2.component.css']
})
export class Sanphamtheoloai2Component extends BaseComponent implements OnInit {
index:any;size:any;
sptheoloai2:any;
tongsl2:any;
  constructor(injector:Injector) {
    super(injector)
   }

  ngOnInit(): void {
    
    this.index=1;this.size=20;this.tongsl2=1;
    this.sptheoloai2=[];
    this._route.params.subscribe(params => {
      let idd = params['id'];
      this._api.get('api/QLSanPham/all-in-loai-2/'+this.index+'/'+this.size+'/'+idd).takeUntil(this.unsubscribe).subscribe(res => {
        this.sptheoloai2 = res;
        this.tongsl2=res[0].total;
      setTimeout(() => {
        this.loadScripts();
      },);
      }); 
    }, err => { });

  }
  loadPage(page) { 
    this._route.params.subscribe(params => {
      let id = params['id'];
      this._api.get('api/QLSanPham/all-in-loai-2/'+page+'/'+this.size+'/'+id).takeUntil(this.unsubscribe).subscribe(res => {
        this.sptheoloai2 = res;
        this.tongsl2=res[0].total;
        }, err => { });       
   });   
  }
  addToCart(it) { 
    this._cart.addToCart(it);
    alert('Thêm thành công!'); 
  }
  addToWishlist(it) { 
    this._wishlist.addToWishlist(it);
    alert('đã thêm vào danh sách yêu thích!'); 
  }
 
  sortByPriceI(arr){
    arr=arr.sort(function(a,b){
      return b.tenSanPham-a.tenSanPham;
    }
    )
  }
}
