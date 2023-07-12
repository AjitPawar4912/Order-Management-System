import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { product } from 'src/app/Models/allModels';
import { ProductService } from 'src/app/Service/product.service';

@Component({
  selector: 'app-seller-add-product',
  templateUrl: './seller-add-product.component.html',
  styleUrls: ['./seller-add-product.component.css']
})
export class SellerAddProductComponent implements OnInit {

  addProductMessage:string|undefined;

  constructor(private product:ProductService, private router:Router) { }

  ngOnInit():void {
  }
  submitProduct(data:product){

    this.product.addProduct(data).subscribe((result)=>{
      console.warn(result);
      if(result){
        this.addProductMessage="Product is Successfully added..!";
      }
      setTimeout(()=>{
        this.addProductMessage=undefined,
        this.router.navigate(['seller-home'])
      },2000);

    })
  }

}
