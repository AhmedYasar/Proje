import { Component, OnInit } from '@angular/core';
import { Urun } from '../../models/urun';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../services/auth.service';
import { SepetService } from '../../services/sepet.service';
import { Sepet } from '../../models/sepet';
import { UrunService } from '../../services/urun.service';
import { EventService } from '../../services/event.service';

@Component({
  selector: 'app-cart-summary',
  templateUrl: './cart-summary.component.html',
  styleUrl: './cart-summary.component.css'
})
export class CartSummaryComponent implements OnInit {
  
  

  sepetler:Sepet[]=[]
  urunler:Urun[]=[]
  kullanıcıId:number=this.getUserId()
  constructor( private eventService:EventService,private toastrService:ToastrService,private authService:AuthService,private sepetService:SepetService,private urunService:UrunService){

  }

  ngOnInit():void{
    this.getSepet()
    this.eventService.sepetGuncellendi$.subscribe(() => {
      this.getSepet();
    });
  
  }



 

 getSepet(){
    this.sepetService.list(this.kullanıcıId).subscribe(response=>{
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

    removeFromCart(sepet:Sepet,urun:Urun){

      this.sepetService.deleteToCart({
        sepetId:sepet.sepetId,
        kullaniciId:this.kullanıcıId,
        urunId:urun.urunId,
        adet:sepet.adet,
        toplamFiyat:sepet.toplamFiyat
        
      }).subscribe(response=>{
        this.toastrService.error(response.message)
        this.eventService.triggerSepetGuncellendi();
      })
      
    }

    getUserId(){
      return this.authService.getUserId()
     }


}
