import { calcPossibleSecurityContexts } from '@angular/compiler/src/template_parser/binding_parser';
import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { CheckoutComponent } from 'src/app/giohang/checkout/checkout.component';
import { BaseComponent } from 'src/app/services/base.component';
declare var $: any;
@Component({
  selector: 'app-diachi',
  templateUrl: './diachi.component.html',
  styleUrls: ['./diachi.component.css']
})
export class DiachiComponent extends BaseComponent implements OnInit {
tk:any;
dsdiachi:any;
public formdata:any;
public doneSetupForm:any;
public showUpdateModal:any;
public isCreate:any;
diachi:any;
dstinh:any;
dshuyen:any;
dsxa:any;
  constructor(private fb:FormBuilder,injector:Injector) {
    super(injector);
   
  }

  ngOnInit(): void {
    document.title='Địa chỉ của tôi';
    this.taiKhoan();
    this.getDiaChi();
    this.gettinh();
    this.loadScripts();
  }
  get f() { return this.formdata.controls; }
  taiKhoan(){
    this._login.items.subscribe((res) => {
      this.tk = res;
     
    });
  }
  getDiaChi(){
    this._api.get('api/QLKhachHang/dia-chi/'+this.tk[0].maKhachHang).takeUntil(this.unsubscribe).subscribe(dau => {
      this.dsdiachi = dau;
    }); 
  }
  thietLapDiaChi(id){
    if(confirm('bạn có muốn chuyển địa chỉ này thành địa chỉ mặc định?')){
      this._api.get('api/QLKhachHang/thiet-lap-dc/'+Number.parseInt(id)).takeUntil(this.unsubscribe).subscribe(dau => {
        alert('đã thiết lập địa chỉ.');
        window.location.reload();
        }); 
    }
  }
  xoaDiaChi(id){
    if(confirm('bạn có muốn xóa địa chỉ này không?')){
      this._api.get('api/QLKhachHang/xoa-dc/'+Number.parseInt(id)).takeUntil(this.unsubscribe).subscribe(dau => {
        alert('đã xóa địa chỉ');
        window.location.reload();
        }); 
    }
  }
  gettinh(){
    this._api.get('api/QLDonHang/get-all-tinh').takeUntil(this.unsubscribe).subscribe(dau => {
      this.dstinh = dau;
    }); 
  }
  gethuyenbytinh(matinh){
    this.dshuyen=[];
    if(matinh!="tinh"){
      this._api.get('api/QLDonHang/get-huyen-by-tinh/'+matinh).takeUntil(this.unsubscribe).subscribe(res => {
        this.dshuyen = res;
     
    });}
      
   }
   getxabyhuyen(mahuyen){
    this.dsxa=[];
    if(mahuyen!="huyen"){
      this._api.get('api/QLDonHang/get-xa-by-huyen/'+mahuyen).takeUntil(this.unsubscribe).subscribe(res => {
        this.dsxa = res;
   
    });}
    
  }
  formThemDiaChi(){
    this.doneSetupForm = false;
  this.showUpdateModal = false;
  this.isCreate = true;

  
  setTimeout(() => {
    $('#DiaChiModal').modal('toggle');
    this.formdata = this.fb.group({
      'tinh': ['', Validators.required],
      'huyen': ['', Validators.required],
      'xa': ['', Validators.required],
      'chitiet': [''],
      'sdt': ['', Validators.required],
    });
    this.doneSetupForm = true;
  });
  }
  fromCapNhatDiaChi(row){
    this.doneSetupForm = false;
    this.showUpdateModal = true; 
    this.isCreate = false;
    setTimeout(() => {
      $('#DiaChiModal').modal('toggle');
      this._api.get('api/qlkhachhang/dia-chi-by-id/'+ row).takeUntil(this.unsubscribe).subscribe((res:any) => {
        this.diachi = res; 
        // let ngaysinh = new Date(this.single_item.ngaysinh);
          this.formdata = this.fb.group({
            'tinh': [this.diachi.tinh, Validators.required],
            'huyen': [this.diachi.huyen, Validators.required],
            'xa': [this.diachi.xa, Validators.required],
            'chitiet': [this.diachi.chiTiet],
            'sdt': [this.diachi.soDienThoai, Validators.required],
          }); 
          this.doneSetupForm = true;
        }); 
    }, 700);
  }
  closeModal(){
    $('#DiaChiModal').closest('.modal').modal('hide');
  }
  reset(){
    this.formdata = this.fb.group({
      'tinh': ['', Validators.required],
      'huyen': ['', Validators.required],
      'xa': ['', Validators.required],
      'chitiet': [''],
      'sdt': ['', Validators.required],
    });
  }
  onSubmit(value){
    let tmp={
      maKhachHang:this.tk[0].maKhachHang,
      xa:Number.parseInt(value.xa),
      huyen:Number.parseInt(value.huyen),
      tinh:Number.parseInt(value.tinh),
      chiTiet:value.chitiet,
      soDienThoai:value.sdt,
    }
    if(this.isCreate) { 
      this._api.post('api/QLKhachHang/them-dc',tmp).takeUntil(this.unsubscribe).subscribe(res => {
        alert('Thêm thành công');
       window.location.reload();
        this.closeModal();
        });
    }
  }
}
