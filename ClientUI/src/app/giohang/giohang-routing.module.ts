import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CheckoutComponent } from './checkout/checkout.component';
import { GiohangComponent } from './giohang.component';


const routes: Routes = [
{path:'',component:GiohangComponent
},
{path:'check-out',component:CheckoutComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GiohangRoutingModule { }
