import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import {ListResponseModel} from '../models/listResponseModel';
import { Urun } from '../models/urun';
import { ResponseModel } from '../models/responseModel';
import { SingleResponseModel } from '../models/singleResponseModel';
@Injectable({
  providedIn: 'root'
})
export class UrunService {
  apiUrl = "https://localhost:7009/api/"
  constructor(private httpClient: HttpClient) { }

  getUrunler():Observable<ListResponseModel<Urun>> {
    let newPath=this.apiUrl+"urunler/getall"
    return this.httpClient.get<ListResponseModel<Urun>>(newPath)
  }

  getUrunlerByKategori(kategoriId:number):Observable<ListResponseModel<Urun>> {
    let newPath=this.apiUrl+"urunler/getbykategori?kategoriId="+kategoriId
    return this.httpClient.get<ListResponseModel<Urun>>(newPath)
  }
  
  add(urun:Urun):Observable<ResponseModel>{
    urun.eklenmeTarihi=new Date
    return this.httpClient.post<ResponseModel>(this.apiUrl+"urunler/add",urun)
  }

  getUrun(urunId:number):Observable<SingleResponseModel<Urun>>{
    let newPath=this.apiUrl+"urunler/getbyid?urunId="+urunId
    return this.httpClient.get<SingleResponseModel<Urun>>(newPath)
  }
 
  updateUrun(urun:Urun):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"urunler/update",urun)
  }
  


}

