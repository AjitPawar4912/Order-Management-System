import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CartComponent } from './cart/cart.component';
import { CheckOutComponent } from './check-out/check-out.component';
import { CustomerSignupComponent } from './Customer/customer-signup/customer-signup.component';
import { HomeComponent } from './Home/home/home.component';
import { MyOrderComponent } from './my-order/my-order.component';
import { ProductDetailsComponent } from './Product/product-details/product-details.component';
import { SearchComponent } from './search/search.component';
import { SellerAddProductComponent } from './Seller/seller-add-product/seller-add-product.component';
import { SellerHomeComponent } from './Seller/seller-home/seller-home.component';
import { SellerRegisterComponent } from './Seller/seller-register/seller-register.component';
import { SellerUpdateProductComponent } from './Seller/seller-update/seller-update.component';

const routes: Routes = [
  {
    path:'',component:HomeComponent
  },
  {
    path:'seller-register',component:SellerRegisterComponent
  },
  {
    path:'seller-home',component:SellerHomeComponent
  },
  {
    path:'seller-add-product',component:SellerAddProductComponent
  },
  {
    path:'seller-update/:productId',component:SellerUpdateProductComponent
  },
  {
    path:'search/:query',component:SearchComponent
  },
  {
    path:'details/:productId',component:ProductDetailsComponent
  },
  {
    path:'cart',component:CartComponent
  },
  {
    path:'check-out',component:CheckOutComponent
  },
  {
    path:'my-order',component:MyOrderComponent
  },
  {
    path:'customer-auth',component:CustomerSignupComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
