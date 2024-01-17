import { LoginModel } from "./loginModel";


export interface RegisterModel extends LoginModel {
    ad:string
    soyad:string
}