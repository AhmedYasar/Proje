import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators ,FormControl} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  darkMode: string = "light";
  registerForm:FormGroup

  constructor(private formBuilder:FormBuilder,private toastrService:ToastrService,private authService:AuthService,private router:Router ){}


  ngOnInit(): void {
    this.createRegisterForm()
  }

  createRegisterForm(){
    this.registerForm=this.formBuilder.group({
      email:["",Validators.required],
      sifre:["",Validators.required],
      ad:["",Validators.required],
      soyad:["",Validators.required]
    })
  }

  register(){
    if(this.registerForm.valid){
      let registerModel= Object.assign({},this.registerForm.value)
      this.authService.register(registerModel).subscribe(response=>{
        this.toastrService.info(response.message)
        localStorage.setItem("token",response.data.token)
        this.router.navigate(["/anasayfa"])
      },responseError=>{
        this.toastrService.error("Form bilgilerinde hata var")
      })
    }
  }
  toggleDarkMode() {
    this.darkMode = this.darkMode==="light"? "dark":"light"
  }

}
