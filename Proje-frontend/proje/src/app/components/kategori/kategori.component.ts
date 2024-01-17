import { Component, OnInit } from '@angular/core';
import { Kategori } from '../../models/kategori';
import { UrunService } from '../../services/urun.service';
import { KategoriService } from '../../services/kategori.service';

@Component({
  selector: 'app-kategori',
  templateUrl: './kategori.component.html',
  styleUrl: './kategori.component.css'
})
export class KategoriComponent implements OnInit {


  kategoriler: Kategori[]
  currentKategori: Kategori
  constructor(private kategoriService: KategoriService) {

  }
  ngOnInit(): void {
    this.getKategoriler()
  }
  getKategoriler() {
    this.kategoriService.getKategoriler().subscribe(response => {
      this.kategoriler = response.data

    })

  }

  setCurrentKategori(kategori: Kategori) {
    this.currentKategori = kategori
  }
  getCurrentKategoriClass(kategori: Kategori) {
    if (kategori == this.currentKategori) {
      return "list-group-item active"
    }
    else {
      return "list-group-item"
    }

  }

  getAllKategoriClass() {
    if (!this.currentKategori || this.currentKategori == {} as Kategori) {
      return "list-group-item active"
    } else {
      return "list-group-item"
    }
  }

  clearCurrentKategori() {
    this.currentKategori = {} as Kategori
  }
}
