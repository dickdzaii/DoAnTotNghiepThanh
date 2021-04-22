import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from 'src/app/services/base.component';
declare var $:any;
@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent extends BaseComponent implements OnInit {
  cartitems:any;
  totalamount:any;
  total:any;
  formdonhang:FormGroup;formdiachi:any;
  tinhs:any;
  huyens:any
  xas:any;dsdiachi:any;
  summited=false;
  ab:any;khach:any;tg:any;doneSetupForm:any;
  constructor(private fb:FormBuilder,injector: Injector) {
    super(injector);
  }

  ngOnInit(): void {
    document.title='Đặt hàng';
    this.gettinh();
    this.taiKhoan();
    this.getDiaChi();
    this.ab=1;
    this._cart.items.subscribe((res) => {
      this.cartitems = res;
      this.total = 0;
      this.totalamount=0;
      for(let x of this.cartitems){ 
        x.money = Number.parseInt(x.quantity) * Number.parseInt(x.giahientai.gia);
        this.totalamount+=x.quantity;
        this.total += x.quantity * x.giahientai.gia;
       
      }  
    });setTimeout(() => {
      this.loadScripts();
    },);
    this.FormTTDonHang();
  }
  taiKhoan(){
    this._login.items.subscribe((res) => {
      this.khach = res;
     this.tg=this.khach[0];
    
     
    });
  }
  getDiaChi(){
    if(this.tg){
    this._api.get('api/QLKhachHang/dia-chi/'+this.tg.maKhachHang).takeUntil(this.unsubscribe).subscribe(dau => {
      this.dsdiachi = dau;
    }); }
  }
  formThemDiaChi(){
    this.doneSetupForm = false;
 
  setTimeout(() => {
    $('#DiaChiModal').modal('toggle');
    this.formdiachi = this.fb.group({
      'tinh': ['', Validators.required],
      'huyen': ['', Validators.required],
      'xa': ['', Validators.required],
      'chitiet': [''],
      'sdt': ['', Validators.required],
    });
    this.doneSetupForm = true;
  });
  }
  closeModal(){
    $('#DiaChiModal').closest('.modal').modal('hide');
  }
  reset(){
    this.formdiachi = this.fb.group({
      'tinh': ['', Validators.required],
      'huyen': ['', Validators.required],
      'xa': ['', Validators.required],
      'chitiet': [''],
      'sdt': ['', Validators.required],
    });
  }
  onSubmit(value){
    let tmp={
      maKhachHang:this.tg.maKhachHang,
      xa:Number.parseInt(value.xa),
      huyen:Number.parseInt(value.huyen),
      tinh:Number.parseInt(value.tinh),
      chiTiet:value.chitiet,
      soDienThoai:value.sdt,
    }
    { 
      this._api.post('api/QLKhachHang/them-dc',tmp).takeUntil(this.unsubscribe).subscribe(res => {
        alert('Thêm thành công');
       
        this.closeModal();
        window.location.reload();
        });
    }
  }
  FormTTDonHang(){
    if(!this.tg){
      this.formdonhang = this.fb.group({
        hoten:['', Validators.required],
        tinh:['', Validators.required], 
        huyen: ['', Validators.required], 
        xa: ['', Validators.required], 
        sdt : ['', Validators.required],
        diachi:[''],
        email: ['', Validators.required]
      });
    }
    else{
      this.formdonhang = this.fb.group({
        madiachi:['',Validators.required]
      });
    }
   
  }
  get f() { return this.formdonhang.controls; }
  gettinh(){
    this._api.get('api/QLDonHang/get-all-tinh').takeUntil(this.unsubscribe).subscribe(dau => {
      this.tinhs = dau;
    }); 
    
  }
  gethuyenbytinh(matinh){
    this.huyens=[]
    if(matinh!="tinh"){
      this._api.get('api/QLDonHang/get-huyen-by-tinh/'+matinh).takeUntil(this.unsubscribe).subscribe(res => {
        this.huyens = res;
     
    });}
      
   }
   getxabyhuyen(mahuyen){
    this.xas=[];
    if(mahuyen!="huyen"){
      this._api.get('api/QLDonHang/get-xa-by-huyen/'+mahuyen).takeUntil(this.unsubscribe).subscribe(res => {
        this.xas = res;
   
    });}
    
  }
   themdonhang(value){
    this.summited=true;
    let ctdh=[];
    this.cartitems.forEach(element => {
      let singleitem={
        "maSanPham":element.maSanPham,
        "tenSanPham":element.tenSanPham,
        "anh":element.anh,
        "link":element.link,
        "soLuong":Number.parseInt(element.quantity),
        "donGia":Number.parseInt(element.giahientai.gia)
    };
    ctdh.push(singleitem);
    });
    let hoadon;
    if(this.tg){
       hoadon = {
        maKH:this.tg.maKhachHang,
        maShop:'S0001',
        thanhToan:1,
        maDiaChi:Number.parseInt(value.madiachi),
        chitiet:ctdh,
          tenKH:null,
          email:null,
         soDienThoai:null,
         xa:null,
         huyen:null,
         tinh:null,
         dcChitiet:null,
        };
    }
     else 
     { hoadon = {
       maKH:null,
       maShop:'S0001',
       thanhToan:1,
       maDiaChi:null,
       chitiet:ctdh,
         tenKH:value.hoten,
         email:value.email,
        soDienThoai:value.sdt,
        xa:Number.parseInt(value.xa),
        huyen:Number.parseInt(value.huyen),
        tinh:Number.parseInt(value.tinh),
        dcChitiet:value.diachi,
       };}
       
      this._api.post('api/QLDonHang/them', hoadon).takeUntil(this.unsubscribe).subscribe(res => {
        
        alert('Đặt hàng thành công');
        this._cart.clearCart();
        window.location.replace('');
         }, err => { });      
   
    
  }
  }
  


