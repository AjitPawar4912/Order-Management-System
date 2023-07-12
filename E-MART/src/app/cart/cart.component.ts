import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { cart, priceSummary } from '../Models/allModels';
import { ProductService } from '../Service/product.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cartData: cart[] | undefined;
  priceSummary: priceSummary = {
    price: 0,
    discount: 0,
    tax: 0,
    deliveryCharge: 0,
    total: 0,
  };
  constructor(private product: ProductService,private router:Router) {}

  ngOnInit(): void {
    this.loadDetails();
  }
  removeToCart(cartId:number | undefined){
    cartId && this.cartData &&this.product.removeToCart(cartId)
        .subscribe((result) => {
          this.loadDetails();

          // alert("you have succesfully removed item from cart");

        })

  }

  loadDetails(){
    this.product.currentCart().subscribe((result) => {
      this.cartData = result;
      let price = 0;
      result.forEach((item) => {
        if(item.quantity){

          price = price + (+item.price* + item.quantity);
        }
      });
      this.priceSummary.price=price;
      this.priceSummary.discount=price/15;
      this.priceSummary.tax=price/5;
      this.priceSummary.deliveryCharge=100;
      this.priceSummary.total=price+(price/15)+100-(price/5);
      if(!this.cartData.length){
        this.router.navigate(['/'])
      }

    });

  }

  checkout(){
    this.router.navigate(['/check-out'])
  }
}




