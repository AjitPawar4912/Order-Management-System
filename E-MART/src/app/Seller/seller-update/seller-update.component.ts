import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { product } from 'src/app/Models/allModels';
import { ProductService } from 'src/app/Service/product.service';

@Component({
  selector: 'app-seller-update',
  templateUrl: './seller-update.component.html',
  styleUrls: ['./seller-update.component.css']
})
export class SellerUpdateProductComponent implements OnInit {
  productData:undefined | product;
  productMessage:undefined | string;
  constructor(private route:ActivatedRoute, private product:ProductService,private router:Router) { }

  ngOnInit(): void {
    let productId=this.route.snapshot.paramMap.get('productId')
    console.warn(productId);
    productId &&this.product.getProduct(productId).subscribe((data)=>{
      console.warn(data);
      this.productData=data
    })
  }
  submitProduct(data:product){
    console.warn(data);
    if(this.productData){
      data.productId=this.productData.productId
    }
    this.product.updateProduct(data).subscribe((result)=>{
      if(result){
        this.productMessage="Product has Updated..!"
      }
    });
    setTimeout(() => {
      this.productMessage=undefined;
      this.router.navigate(['seller-home'])
    }, 3000);

  }

}

