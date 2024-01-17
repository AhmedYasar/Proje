import { Component, OnInit } from '@angular/core';
import { Sepet } from '../../models/sepet';
import { Urun } from '../../models/urun';
import { SepetService } from '../../services/sepet.service';
import { AuthService } from '../../services/auth.service';
import { UrunService } from '../../services/urun.service';
import { ToastrService } from 'ngx-toastr';
import { EventService } from '../../services/event.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-sepet',
  templateUrl: './sepet.component.html',
  styleUrl: './sepet.component.css'
})
export class SepetComponent implements OnInit {
  
 sepetForm:FormGroup
 sepetler:Sepet[]
 urunler:Urun[]
 toplamTutar:number
 yeniAdet:number
 userId:number=this.authService.getUserId()
  constructor(private formsBuilder: FormBuilder,private eventService:EventService,private sepetService:SepetService,private authService:AuthService,private urunService:UrunService,private toastrService:ToastrService){}
  ngOnInit(): void {
    this.sepetler=[]
    this.urunler=[]
    this.getSepet()
    this.sepetForm = this.formsBuilder.group({
      adet: [1, [Validators.required, Validators.min(1)]]
    });

    this.eventService.sepetGuncellendi$.subscribe(() => {
      this.getSepet();
    });
  }
  
  
  getSepet(){
  
    this.sepetService.list(this.userId).subscribe(response=>{
      this.toastrService.success(response.message)
      this.sepetler=response.data
      
      this.getUrun()
    })

  }

  
  async getUrun(){
    if(this.urunler.length>0) {
      this.urunler=[]
    }
    if(this.sepetler.length>0){
      for (let i = 0; i < this.sepetler.length; i++) {
        await this.urunService.getUrun(this.sepetler[i].urunId).toPromise().then(response => {
          this.urunler.push(response.data);
        });
      }
    }
  }

 removeSepet(sepet:Sepet){
  this.sepetService.deleteToCart(sepet).subscribe(response=>{
    this.toastrService.success(response.message)
    this.eventService.triggerSepetGuncellendi();
   
  })
 }
  addSepet(sepet:Sepet){
    if(this.authService.isAuthenticated()){

      this.sepetService.addToCart(sepet).subscribe(response=>{
        this.toastrService.success(response.message)
        
      })
      
    }
  }

  updateSepet(sepet:Sepet,urun:Urun){
    sepet.toplamFiyat = urun.urunFiyati * sepet.adet;
    this.sepetService.updateToCart(sepet).subscribe(response=>{
      this.toastrService.success(response.message)
     this.eventService.triggerSepetGuncellendi();
    })
  }

 getTotal():number{
  this.toplamTutar=0
  for (let i = 0; i < this.sepetler.length; i++) {
   
    this.toplamTutar=this.toplamTutar+(this.sepetler[i].toplamFiyat)
  }
  return this.toplamTutar
  }

  odemeYap() {
    // Sepetteki her ürünü sil ve stok adetlerini güncelle
    this.sepetler.forEach(sepet => {
      this.urunService.getUrun(sepet.urunId).subscribe(response => {
        const urun = response.data;
        
        // Sepetten ürünü sil
        this.sepetService.deleteToCart(sepet).subscribe(() => {
          // Stok adetini güncelle
          urun.urunStok -= sepet.adet;
          this.urunService.updateUrun(urun).subscribe(() => {
            // Başka gerekli işlemleri yapabilirsiniz
          });
        });
        this.eventService.triggerSepetGuncellendi()
      });
    });
  }

}
  
  

