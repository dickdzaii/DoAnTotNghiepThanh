import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/services/base.component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import {Observable, Subject, of, from} from 'rxjs'
@Component({
  selector: 'app-spcungloai',
  templateUrl: './spcungloai.component.html',
  styleUrls: ['./spcungloai.component.css']
})
export class SpcungloaiComponent extends BaseComponent implements OnInit {

  sptuongtu:any;
  constructor(injector:Injector) {
    super(injector);
  }

  ngOnInit(): void {
    this._route.params.subscribe(params => {
      let id = params['id'];
       this._api.get('api/QLSanPham/tuong-tu/'+id).takeUntil(this.unsubscribe).subscribe(res => {
         this.sptuongtu = res;
         setTimeout(() => {
           this.loadScripts();
         });
         
       }); 
     });
  }
  addToCart(it) { 
    this._cart.addToCart(it);
    alert('Thêm thành công!'); 
  }

}
