import { Component, OnInit } from '@angular/core';
import { product } from 'src/app/Models/allModels';
import { ProductService } from 'src/app/Service/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  
  trendyProducts:undefined | product[];
  constructor(private product:ProductService) { }

  ngOnInit() {



     this.product.trendyProducts().subscribe((data)=>{
       this.trendyProducts=data;

     })
  }

}






