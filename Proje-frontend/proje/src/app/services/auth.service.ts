import { Injectable } from '@angular/core';
import { LoginModel } from '../models/loginModel';
import { HttpClient } from '@angular/common/http';
import { TokenModel } from '../models/tokenModel';
import { SingleResponseModel } from '../models/singleResponseModel';
import { RegisterModel } from '../models/registerModel';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  apiUrl = "https://localhost:7009/api/Auth/"

  constructor(private httpClient:HttpClient) { }

  login(loginModel:LoginModel){
    return this.httpClient.post<SingleResponseModel<TokenModel>>(this.apiUrl+"login",loginModel)
  }

  isAuthenticated(){
    if(localStorage.getItem("token")){
      return true
    }else{
      return false
    }
  }

  register(registerModel:RegisterModel){
    return this.httpClient.post<SingleResponseModel<TokenModel>>(this.apiUrl+"register",registerModel)
  }
  

  getToken(): string | null {
    // Token'i localStorage'dan al
    return localStorage.getItem('token');
  }
  
  
   getUserId(): number | null {
    const token = this.getToken();
    if (token) {
      // Token'dan kullanıcı bilgilerini çıkar
      const payload = this.decodeToken(token);
      return payload ? +payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'] : null;
    }
    return null;
  }
  
  private decodeToken(token: string): any {
    try {
      return JSON.parse(atob(token.split('.')[1]));
    } catch (e) {
      return null;
    }
  }

}
