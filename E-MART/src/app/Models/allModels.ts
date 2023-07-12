//for seller signUp
export interface signUp{
  name:string
  emailadress:string
  address:string
  mobile:number
  password:string
}

//for customer signUp

export interface usignUp{
  name:string
  firstname:string
  lasttname:string
  emailadress:string
  password:string
  address:string
  mobile:number

}

//for seller and customer login

export interface login{

  emailadress:string
  password:string
}

//for seller product

export interface product{
  name:string
  price:number
  brandname:string
  category:string
  description:string
  image:string
  id:number
  quantity:undefined | number
  productId:undefined | number
}

export interface cart{
  name:string
  price:number
  brandname:string
  category:string
  description:string
  image:string
  id:number |undefined
  quantity:undefined | number
  userId:number
  productId:number
}

export interface priceSummary{
  price:number
  discount:number
  tax:number
  deliveryCharge:number
  total:number

}

export interface order{
  firstname:string
  emailadress:string
  address:string
  mobile:string
  totalPrice:number
  userId:number
  orderName:string
  quantity:undefined | number
  id:number | undefined
}
