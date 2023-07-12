import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { login, signUp } from 'src/app/Models/allModels';
import { SellerService } from 'src/app/Service/seller.service';

@Component({
  selector: 'app-seller-register',
  templateUrl: './seller-register.component.html',
  styleUrls: ['./seller-register.component.css']
})
export class SellerRegisterComponent implements OnInit {

  constructor(private seller:SellerService,private router:Router) { }
  showLogin = false
  authError:string= '';
  ngOnInit(): void {
    this.seller.reloadseller()
  }

  signUp(data:signUp):void{
    console.warn(data)
    this.seller.sellerSignUp(data)

  }

  login(data:login):void{
    //console.warn(data)
    this.authError='';
    this.seller.sellerLogin(data)
    this.seller.isLoginError.subscribe((isError)=>{
      if(isError){
        this.authError="Incorrect Email or Password"
      }

    })
  }

  openLogin(){
    this.showLogin=true

  }

  openSignUp(){
    this.showLogin=false

  }

}

