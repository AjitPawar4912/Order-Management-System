import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { product } from '../Models/allModels';
import { ProductService } from '../Service/product.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  menuType:string='default';
  sellerName:string='';
  searchResult:undefined | product[];
  userName:string='';
  templateName:string='Hello,'
  cartItems=0;
  constructor(private route:Router,private product:ProductService) { }

  ngOnInit() {
    this.route.events.subscribe((val:any)=>{
      if(val.url){
        if (localStorage.getItem('seller') && val.url.includes('seller')) {
          console.warn('in seller area');
          this.menuType = 'seller';
        if(localStorage.getItem('seller')){
            let sellerStore=localStorage.getItem('seller');
            let sellerData=sellerStore&& JSON.parse(sellerStore)[0];
            this.sellerName=sellerData.sname;
             this.menuType="seller";
          }
        }
                    // this.menuType="user";
        else if(localStorage.getItem('user')){
            let userStore=localStorage.getItem('user');
            let userData=userStore&& JSON.parse(userStore);
            this.userName = userData.firstname;
            this.menuType='user';
            this.product.getCartList(userData.id)


        }else{

          this.menuType='default'

        }
      }

  });


    let cartData = localStorage.getItem('localCart');
    if(cartData){
      this.cartItems=JSON.parse(cartData).length
    }
    this.product.cartData.subscribe((items)=>{
      this.cartItems=items.length

    })
  }

  sellerLogout(){
    localStorage.removeItem('seller');
    this.route.navigate(['']);
  }

  userLogout(){
    localStorage.removeItem('user');
    this.route.navigate(['/customer-auth']);
    this.product.cartData.emit([]);

  }

  searchProduct(query:KeyboardEvent){
    if(query){
      const element=query.target as HTMLInputElement;
      this.product.searchProducts(element.value).subscribe((result)=>{

      if(result.length>5){
      result.length=5;
      }
      this.searchResult=result;
      })
    }

  }
  hideSearch(){
    this.searchResult=undefined
  }
  submitSearch(val:string){

    this.route.navigate([`search/${val}`])

  }
  redirectToDetails(id:number){

    this.route.navigate(['/details/'+id]);

  }

}





