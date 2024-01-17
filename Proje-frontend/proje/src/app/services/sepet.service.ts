import { Injectable } from '@angular/core';
import { Sepet } from '../models/sepet';
import { ListResponseModel } from '../models/listResponseModel';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseModel } from '../models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class SepetService {


  constructor(private httpClient: HttpClient) { }

  apiUrl = "https://localhost:7009/api/"
  addToCart(sepet: Sepet):Observable<ResponseModel> {
    let newPath=this.apiUrl+"sepetler/add"
    return this.httpClient.post<ResponseModel>(newPath,sepet)

  }

  list(userId:number):Observable<ListResponseModel<Sepet>> {
    let newPath=this.apiUrl+"sepetler/getbyuserid?userId="+userId
    return this.httpClient.get<ListResponseModel<Sepet>>(newPath)
  }

  deleteToCart(sepet:Sepet):Observable<ResponseModel>{
    let newPath=this.apiUrl+"sepetler/delete"
    return this.httpClient.post<ResponseModel>(newPath,sepet)
  }

  updateToCart(sepet:Sepet):Observable<ResponseModel>{
    let newPath=this.apiUrl+"sepetler/update"
    return this.httpClient.post<ResponseModel>(newPath,sepet)
  }


}
