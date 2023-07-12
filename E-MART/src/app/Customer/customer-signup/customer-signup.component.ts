import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { cart, login, product, usignUp } from 'src/app/Models/allModels';
import { ProductService } from 'src/app/Service/product.service';
import { UserService } from 'src/app/Service/user.service';

@Component({
  selector: 'app-customer-signup',
  templateUrl: './customer-signup.component.html',
  styleUrls: ['./customer-signup.component.css']
})
export class CustomerSignupComponent implements OnInit {

  showLogin = false;
  authError: string = '';

  constructor(private user: UserService, private product: ProductService, private router:Router) {}
  ngOnInit(): void {
    this.user.userAuthReload();
  }

  signUp(data: usignUp) {
    this.user.userSignUp(data);
  }

  login(data: login) {
    this.user.userLogin(data);
    this.user.invalidUserAuth.subscribe((result) => {
      console.warn('apple', result);
      if (result) {
        this.authError = 'Incorrect Email or Password';
      } else {
        this.localCartToRemoteCart();
      }
    });
  }

  openSignUp() {
    this.showLogin = false;
  }
  openLogin() {
    this.showLogin = true;
  }
  localCartToRemoteCart() {
    let data = localStorage.getItem('localCart');
    let user = localStorage.getItem('user');
      let userId = user && JSON.parse(user).id;
    if (data) {
      let cartDataList: product[] = JSON.parse(data);
      cartDataList.forEach((product: product, index) => {
        let cartData: cart = {
          ...product,
          productId: product.id,
          userId,
        };
        delete cartData.id;
        setTimeout(() => {
          this.product.addToCart(cartData).subscribe((result) => {
            if (result) {
              console.warn('Item stored in DB');
            }
          });
        }, 500);
        if (cartDataList.length === index + 1) {
          localStorage.removeItem('localCart');
        }
      })
    }
    setTimeout(() => {
      this.product.getCartList(userId);

    }, );

  }
}
