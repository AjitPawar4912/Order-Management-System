import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { login, usignUp } from '../Models/allModels';


@Injectable({
  providedIn: 'root'
})
export class UserService {
invalidUserAuth=new EventEmitter<boolean>(false)
private baseUrl:string="https://localhost:44354/api/Users/"
constructor(private http:HttpClient,private router:Router) { }


userSignUp(user:usignUp){
 this.http.post("https://localhost:44354/api/Users",user,{observe:'response'})
  .subscribe((result)=>{
      console.warn(result);
     if(result){
      localStorage.setItem('user',JSON.stringify(result.body))
      this.router.navigate(['/']);
    }
   })
 }

  userLogin(data:login){
 this.http.get<usignUp[]>(`https://localhost:44354/api/Login/login/${data.emailadress}&${data.password}`,

     {observe :'response'}).subscribe((result)=>{
       if(result && result.body?.length){

         this.invalidUserAuth.emit(false)
        localStorage.setItem('user',JSON.stringify(result.body[0]))
         this.router.navigate(['/'])
           }else{
     this.invalidUserAuth.emit(true)
    }

     })

   }



 userAuthReload(){
  if(localStorage.getItem('user')){
    this.router.navigate(['/']);
  }
}


}


