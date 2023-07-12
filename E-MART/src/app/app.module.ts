import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { SellerHomeComponent } from './Seller/seller-home/seller-home.component';
import { SellerRegisterComponent } from './Seller/seller-register/seller-register.component';
import { SellerAddProductComponent } from './Seller/seller-add-product/seller-add-product.component';
import { SearchComponent } from './search/search.component';
import { CustomerSignupComponent } from './Customer/customer-signup/customer-signup.component';
import { ProductDetailsComponent } from './Product/product-details/product-details.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HomeComponent } from './Home/home/home.component';
import { CartComponent } from './cart/cart.component';
import { CheckOutComponent } from './check-out/check-out.component';
import { MyOrderComponent } from './my-order/my-order.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SellerUpdateProductComponent } from './Seller/seller-update/seller-update.component';


@NgModule({
  declarations: [
    AppComponent,
    SellerHomeComponent,
    SellerUpdateProductComponent,
    SellerRegisterComponent,
    SellerAddProductComponent,
    SearchComponent,
    CustomerSignupComponent,
    ProductDetailsComponent,
    NavBarComponent,
    HomeComponent,
    CartComponent,
    CheckOutComponent,
    MyOrderComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
