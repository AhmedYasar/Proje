import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UrunComponent } from './components/urun/urun.component';
import { UrunAddComponent } from './components/urun-add/urun-add.component';
import { LoginComponent } from './components/login/login.component';
import { LoginGuard } from './guards/login.guard';
import { AnasayfaComponent } from './components/anasayfa/anasayfa.component';
import { RegisterComponent } from './components/register/register.component';
import { SepetComponent } from './components/sepet/sepet.component';

const routes: Routes = [
  {path:"",pathMatch:"full",component:AnasayfaComponent},
  {path:"urunler",component:UrunComponent},
  {path:"urunler/kategori/:kategoriId",component:UrunComponent},
  {path:"urunler/add",component:UrunAddComponent, canActivate:[LoginGuard]},
  {path:"login",component:LoginComponent},
  {path:"anasayfa",component:AnasayfaComponent},
  {path:"urunler/urun/:urunId",component:UrunComponent},
  {path:"register",component:RegisterComponent},
  {path:"sepet",component:SepetComponent,canActivate:[LoginGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
