import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChitietComponent } from './chitiet/chitiet.component';
import { DanhsachComponent } from './danhsach/danhsach.component';
import { SanphamComponent } from './sanpham.component';
import { SptheohangComponent } from './sptheohang/sptheohang.component';
import { Sanphamtheoloai2Component } from './sanphamtheoloai2/sanphamtheoloai2.component';
import { SptheoloaiComponent } from './sptheoloai/sptheoloai.component';
import { Sanphamtheoloai1Component } from './sanphamtheoloai1/sanphamtheoloai1.component';


const routes: Routes = [
{path:'',component:SanphamComponent,
children:[
  {
    path:':id',component:Sanphamtheoloai2Component
  },
  {
    path:'loai-1/:id',component:Sanphamtheoloai1Component
  },
 
  {
    path:'danh-muc/:id',component:SptheoloaiComponent
  }
 
]
},
{path:'chi-tiet/:id',component:ChitietComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SanphamRoutingModule { }
