import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { UrunService } from '../../services/urun.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


@Component({
  selector: 'app-urun-add',
  templateUrl: './urun-add.component.html',
  styleUrl: './urun-add.component.css'
})
export class UrunAddComponent implements OnInit {

  urunAddForm: FormGroup

  constructor(private formsBuilder: FormBuilder,private urunSevice:UrunService,private toastrService:ToastrService,private router:Router) {

  }

  ngOnInit(): void {
    this.createUrunAddForm()
  }

  createUrunAddForm() {
    this.urunAddForm = this.formsBuilder.group({
      urunAdi: ["", Validators.required],
      urunTanimi: ["", Validators.required],
      urunFiyati: ["", Validators.required],
      urunStok: ["", Validators.required],
      urunResimURL: ["", Validators.required],
      kategoriId:["", Validators.required],
      ureticiId: ["", Validators.required]
    })
  }


  add(){
    if(this.urunAddForm.valid){
       let urunModel =Object.assign({},this.urunAddForm.value)
       this.urunSevice.add(urunModel).subscribe(response=>{
         this.toastrService.success(response.message,"Başarılı")
         this.router.navigate(["/add"])
       },responseError=>{
        if(responseError.error.Errors.length>0){
          for (let i = 0;i<responseError.error.Errors.length; i++) {
            this.toastrService.error(responseError.error.Errors[i].ErrorMessage,"Doğrulama hatası")
          }
        }
        else{
          console.log(responseError)
           this.toastrService.error(responseError,"Hata")
        }
       
       })
      
    }else{
      this.toastrService.error("Fromunuz eksik","Uyarı")
    }
   
    
  }

}
