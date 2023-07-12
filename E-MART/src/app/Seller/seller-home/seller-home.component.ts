import { Component, OnInit } from '@angular/core';
import { product } from 'src/app/Models/allModels';
import { ProductService } from 'src/app/Service/product.service';


@Component({
  selector: 'app-seller-home',
  templateUrl: './seller-home.component.html',
  styleUrls: ['./seller-home.component.css']
})
export class SellerHomeComponent implements OnInit {
  productList:undefined | product[]
  productMessage:undefined | string;

  constructor(private product:ProductService) { }

  ngOnInit():void {
    this.list();
  }
   deleteProduct(productId:any){
     console.warn("test id",productId)
     this.product.deleteProduct(productId).subscribe((result)=>{
       if(result){
         this.productMessage="Product is Deleted..!";
         this.list()

       }

     })

     setTimeout(() => {
       this.productMessage=undefined
     }, 3000);

   }
   list(){
    this.product.productList().subscribe((result)=>{
      console.warn(result)
      this.productList=result;

    })

   }

}

