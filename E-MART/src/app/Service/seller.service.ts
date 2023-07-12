import { EventEmitter, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';
import { login, signUp } from '../Models/allModels';

@Injectable({
  providedIn: 'root',
})
export class SellerService {
  isSellerLogedIn = new BehaviorSubject<boolean>(false);
  isLoginError =new EventEmitter<boolean>(false)

  constructor(private http: HttpClient, private router: Router) {}



  sellerSignUp(data: signUp) {

    this.http.post('https://localhost:44354/api/Sellers', data, { observe: 'response' })
      .subscribe((result) => {
        this.isSellerLogedIn.next(true);
        localStorage.setItem('seller', JSON.stringify(result.body));
        this.router.navigate(['seller-home']);
      });
  }
  reloadseller() {
    if (localStorage.getItem('seller')) {
      this.isSellerLogedIn.next(true);
      this.router.navigate(['seller-home']);
    }
  }

  sellerLogin(data:login){
  console.warn(data)


  this.http.get(`http://localhost:4000/seller?emailaddress=${data.emailadress}&password=${data.password}`,
  {observe :'response'}
  ).subscribe((result:any)=>{
    console.warn(result)
    if (result&&result.body &&result.body.length){
      console.warn("Seller Logged in Successfully.....!")
      localStorage.setItem('seller', JSON.stringify(result.body))
      this.router.navigate(['seller-home'])
    }else{
      console.warn("Login failed...!");
      this.isLoginError.emit(true)
    }
  })
  }


}
