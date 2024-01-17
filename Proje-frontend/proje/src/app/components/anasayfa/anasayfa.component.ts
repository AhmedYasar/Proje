import { Component, OnInit } from '@angular/core';
import { Urun } from '../../models/urun';
import { UrunService } from '../../services/urun.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-anasayfa',
  templateUrl: './anasayfa.component.html',
  styleUrl: './anasayfa.component.css'
})
export class AnasayfaComponent implements OnInit {
  urunler: Urun[] = [];
  randomIndexes: number[] = [];
  rastgeleUrunler: Urun[] = [];
  currentUrun:Urun
  constructor(private urunService:UrunService,private activatedRoute:ActivatedRoute){}

  ngOnInit(): void {
    
    this.getUrunler()
    
  }




  getUrunler(){
    this.urunService.getUrunler().subscribe(response=>{
      this.urunler=response.data
      this.generateRandomIndexes()
      this.selectRandomProducts()
    })
   }
  private generateRandomIndexes(): void {
    const totalProducts = this.urunler.length;

    // Rastgele indexleri oluştur
    while (this.randomIndexes.length < 6) {
      const randomIndex = Math.floor(Math.random() * totalProducts);

      if (!this.randomIndexes.includes(randomIndex)) {
        this.randomIndexes.push(randomIndex);
      }
    }
  }

  private selectRandomProducts(): void {
    // Rastgele seçilen ürünleri al
    this.rastgeleUrunler = this.randomIndexes.map(index => this.urunler[index]);
  }


}


