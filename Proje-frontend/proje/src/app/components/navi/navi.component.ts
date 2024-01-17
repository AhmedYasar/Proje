import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { NavigationEnd, Router } from '@angular/router';
import { EventService } from '../../services/event.service';

@Component({
  selector: 'app-navi',
  templateUrl: './navi.component.html',
  styleUrl: './navi.component.css'
})
export class NaviComponent implements OnInit {

  isLoggedIn:boolean
  isSepetPage:boolean=false
  constructor(private eventService:EventService ,private authService:AuthService,private router:Router){

  }

  ngOnInit(): void {
    this.isAuthenticated()
    this.sayfaKontorl()
  }

  isAuthenticated(){
    return this.isLoggedIn=this.authService.isAuthenticated()

  }

  logout(){
      localStorage.removeItem("token")
      this.isAuthenticated()
      this.router.navigate(["/anasayfa"])
      this.eventService.triggerSepetGuncellendi();
  }


   sayfaKontorl(){
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.isSepetPage = this.router.url.includes('/sepet'); // Seçtiğiniz sepet sayfasının URL'sini kontrol edin
      }else{
        this.isSepetPage=false
      }
    });
   }
}
