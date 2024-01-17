import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Kategori } from '../models/kategori';
import { Observable } from 'rxjs';
import {ListResponseModel} from '../models/listResponseModel';
@Injectable({
  providedIn: 'root'
})
export class KategoriService {


  apiUrl = "https://localhost:7009/api/Kategoriler/getall"
  constructor(private httpClient:HttpClient) { }

  getKategoriler():Observable<ListResponseModel<Kategori>>{
    return this.httpClient.get<ListResponseModel<Kategori>>(this.apiUrl)
  }


}
