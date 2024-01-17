import { Component, OnInit } from '@angular/core';
import { Urun } from '../../models/urun';
import { UrunService } from '../../services/urun.service';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../services/auth.service';
import { SepetService } from '../../services/sepet.service';
import { EventService } from '../../services/event.service';
@Component({
  selector: 'app-urun',
  templateUrl: './urun.component.html',
  styleUrl: './urun.component.css'
})
export class UrunComponent implements OnInit {

  urunler: Urun[] =[]
  dataLoaded=false
  filterText=""
  kullanıcıId:number=this.getUserId()


  constructor(private eventService:EventService ,private urunService:UrunService , 
    private activatedRoute:ActivatedRoute,private toastrService:ToastrService,
    private authService:AuthService,private sepetService:SepetService) {

  }
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["kategoriId"]){
        this.getUrunlerByKategori(params["kategoriId"])
      }else if(params["urunId"]){
        this.getUrunDetails(params["urunId"])
      }else{
        this.getUrunler()
      }
    })
    
  }
  getUrunDetails(urunId:number){
    this.urunService.getUrun(urunId).subscribe(response=>{
      this.urunler.push(response.data)
      this.dataLoaded=true
    })

  }

 getUrunler(){
  this.urunService.getUrunler().subscribe(response=>{
    this.urunler=response.data
    this.dataLoaded=true
    console.log(this.urunler)
  })
 }
 getUrunlerByKategori(kategoriId:number){
  this.urunService.getUrunlerByKategori(kategoriId).subscribe(response=>{
    this.urunler=response.data
    this.dataLoaded=true
  })
 }

 addToCart(urun:Urun){

    if(this.authService.isAuthenticated()){

    this.sepetService.addToCart({
      kullaniciId:this.kullanıcıId,
      urunId:urun.urunId,
      adet:1,
      toplamFiyat:urun.urunFiyati
    }).subscribe(response=>{
      this.toastrService.success("Sepete eklendi ",urun.urunAdi)
      this.eventService.triggerSepetGuncellendi();
    })
    }else{
      this.toastrService.error("Lütfen giriş yapın")
    }
 }

 getUserId(){
  return this.authService.getUserId()
 }




}