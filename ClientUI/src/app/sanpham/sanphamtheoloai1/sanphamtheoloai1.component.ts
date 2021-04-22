import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/services/base.component';

@Component({
  selector: 'app-sanphamtheoloai1',
  templateUrl: './sanphamtheoloai1.component.html',
  styleUrls: ['./sanphamtheoloai1.component.css']
})
export class Sanphamtheoloai1Component extends BaseComponent implements OnInit {
index:any;size:any;response:any;
sptheoloai1:any;
tongsl1:any;
  constructor(injector:Injector) {
    super(injector)
   }

  ngOnInit(): void {
    
    this.index=1;this.size=20;this.tongsl1=1;
    this.sptheoloai1=[];
    this._route.params.subscribe(params => {
      let idd = params['id'];
      this._api.get('api/QLSanPham/all-in-loai-1/'+this.index+'/'+this.size+'/'+idd).takeUntil(this.unsubscribe).subscribe(res => {
        this.response = res;
        this.sptheoloai1=this.response.data;
        this.tongsl1=this.response.totalItems;
       setTimeout(() => {
         this.loadScripts();
       }, );
      }); 
    }, err => { });

  }
  loadPage(page) { 
    this._route.params.subscribe(params => {
      let id = params['id'];
      this._api.get('api/QLSanPham/all-in-loai-1/'+page+'/'+this.size+'/'+id).takeUntil(this.unsubscribe).subscribe(res => {
        this.response = res;
        this.sptheoloai1=this.response.data;
        this.tongsl1=this.response.totalItems;
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
