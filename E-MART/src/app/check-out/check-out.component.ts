import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { cart, order } from '../Models/allModels';
import { ProductService } from '../Service/product.service';

@Component({
  selector: 'app-check-out',
  templateUrl: './check-out.component.html',
  styleUrls: ['./check-out.component.css']
})
export class CheckOutComponent implements OnInit {

  totalPrice: number | undefined;
  cartData:cart[] | undefined;
  orderMessage:string | undefined;
  constructor(private product: ProductService,private router:Router) {}

  ngOnInit(): void {
    this.product.currentCart().subscribe((result) => {
      let price = 0;
      this.cartData=result;
      result.forEach((item) => {
        if (item.quantity) {
          price = price + +item.price * +item.quantity;
        }
      });
      this.totalPrice = price + price / 15 + 100 - price / 5;
      console.warn(this.totalPrice);
    });
  }

  orderNow(data: order) {
    console.warn(data);
    let user = localStorage.getItem('user');
    let userId = user && JSON.parse(user).userId;
    if (this.totalPrice) {
      let orderData: order = {
        ...data,
        totalPrice: this.totalPrice,
        userId,
        id:undefined
      }

      this.cartData?.forEach((item)=>{
        setTimeout(() => {
          item.id && this.product.deleteCartItems(item.id)

        }, 500);

      })
      this.product.orderNow(orderData).subscribe((result) => {
        if (result) {
           alert('oder Placed Successfully..!');
          this.orderMessage="Your Order has been Placed Successfully..!";
          setTimeout(() => {
            this.router.navigate(['my-order'])
            this.orderMessage=undefined

          }, 4000);
        }
      });
    }
  }
}




