import { Component, OnInit,Injector } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import {  combineLatest } from 'rxjs';
import { BaseComponent } from '../services/base.component';
declare var $:any;
@Component({
  selector: 'app-dangnhapdangky',
  templateUrl: './dangnhapdangky.component.html',
  styleUrls: ['./dangnhapdangky.component.css']
})
export class DangnhapdangkyComponent extends BaseComponent implements OnInit {
  formdata:any;taikhoan:any;
  formDangKy:any;
  public submitted:any;
  submit_error:any;
  constructor(private router: Router,private fb:FormBuilder,injector: Injector) { 
    super(injector);
  }
  get f() { return this.formdata.controls; }
  ngOnInit(): void {
    this.submitted=false;
    this.formLogin();
    this.loadScripts();
    this.formRegister();
  }
  dangNhap(value){
    let errorbar=document.getElementById('error_bar');
    this.submitted=true;
    this.submit_error=false;
    let tmp={
      tk:value.tendangnhap,
      emk:value.matkhau,
      email:value.tendangnhap
    }
    this._api.post('api/QLKhachHang/login',tmp).takeUntil(this.unsubscribe).subscribe(res => {
    this.taikhoan=res;
    if(this.formdata.get('tendangnhap')=='')
    {
      errorbar.style.display='';
      document.getElementById('error_type').innerHTML='Đăng nhập thất bại!';
      document.getElementById('error_message').innerHTML='Vui lòng nhập tên đăng nhập';
    }
    if(this.formdata.get('matkhau')=='')
    {
      errorbar.style.display='';
      document.getElementById('error_type').innerHTML='Đăng nhập thất bại!';
      document.getElementById('error_message').innerHTML='Vui lòng nhập mật khẩu';
    }
    if(this.taikhoan) {
    
      
      this._login.login(this.taikhoan);
     alert('đăng nhập thành công');
     window.history.back();
    }
   
    else
    {
      this.submitted=false;
      this.submit_error=true;
      errorbar.style.display='';
      document.getElementById('error_type').innerHTML='Đăng nhập thất bại!';
      document.getElementById('error_message').innerHTML='Tên tài khoản hoặc mật khẩu không chính xác';
    }
      }, err => { });       
  }
  register(value){

  }
  hide_error_bar(){
    document.getElementById('error_bar').style.display='none';
  }
  formLogin(){
   
    this.formdata = this.fb.group({
      'tendangnhap': ['', Validators.required],
      'matkhau':['', Validators.required]
    });
   
  }
  formRegister(){
    this.formDangKy = this.fb.group({
      'tendangnhap': ['', Validators.required],
      'matkhau':['', Validators.required],
      'email':['', Validators.email],
      'gioitinh':[''],
      'ngaysinh':[''],

    });
  }

}
