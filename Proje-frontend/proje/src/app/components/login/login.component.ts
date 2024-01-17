import { Component ,OnInit } from '@angular/core';
import { FormGroup,FormBuilder,FormControl,Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  loginForm:FormGroup
  returnUrl: string;
  darkMode: string = "light";

  constructor(private formBuilder:FormBuilder,private authService:AuthService,private toastrService:ToastrService,private router: Router,
    private route: ActivatedRoute){}

  ngOnInit(): void {
    this.createLoginForm()
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }
  createLoginForm(){
    this.loginForm=this.formBuilder.group({
      email:["",Validators.required],
      sifre:["",Validators.required]
    })
  }
  login(){
    if(this.loginForm.valid){
      let loginModel= Object.assign({},this.loginForm.value)
      this.authService.login(loginModel).subscribe(response=>{
        this.toastrService.info(response.message)
        localStorage.setItem("token",response.data.token)
        this.router.navigate([this.returnUrl])
      },responseError=>{
        this.toastrService.error("Kullanıcı adı veya şifre hatalı")
      })
    }
  }

  toggleDarkMode() {
    this.darkMode = this.darkMode==="light"? "dark":"light"
  }

}
