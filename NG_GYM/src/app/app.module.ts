import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './modules/auth/auth.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { IonicModule } from '@ionic/angular';
import { SharedModule } from './modules/shared/shared.module';


@NgModule({
  declarations: [
    AppComponent
    ],
  imports: [
    BrowserModule,
    HttpClientModule,
    IonicModule.forRoot(),
    AppRoutingModule,
    AuthModule,
    SharedModule
  ],
  providers: [
    // {
    //   provide: HTTP_INTERCEPTORS,
    //   useClass: AuthInterceptor,
    //   multi: true
    // }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
