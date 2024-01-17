import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UrunComponent } from './components/urun/urun.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { KategoriComponent } from './components/kategori/kategori.component';
import { NaviComponent } from './components/navi/navi.component';
import { VatAddedPipe } from './pipes/vat-added.pipe';
import { FilterPipePipe } from './pipes/filter-pipe.pipe';

import { ToastrModule } from 'ngx-toastr';
import { CartSummaryComponent } from './components/cart-summary/cart-summary.component';
import { UrunAddComponent } from './components/urun-add/urun-add.component';
import { LoginComponent } from './components/login/login.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { AnasayfaComponent } from './components/anasayfa/anasayfa.component';
import { RegisterComponent } from './components/register/register.component';
import { SepetComponent } from './components/sepet/sepet.component';

@NgModule({
  declarations: [
    AppComponent,
    UrunComponent,
    KategoriComponent,
    NaviComponent,
    VatAddedPipe,
    FilterPipePipe,
    CartSummaryComponent,
    UrunAddComponent,
    LoginComponent,
    AnasayfaComponent,
    RegisterComponent,
    SepetComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      positionClass:"toast-bottom-right"
    })
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS,useClass:AuthInterceptor,multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
