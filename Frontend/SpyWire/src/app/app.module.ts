import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { MainCompComponent } from './main-comp/main-comp.component';
import { SpyItemsComponent } from './main-comp/spy-items/spy-items.component';
import { AddItemComponent } from './main-comp/add-item/add-item.component';
import {HttpClientModule, HTTP_INTERCEPTORS} from "@angular/common/http"
import {FormsModule} from '@angular/forms'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { UserComponent } from './main-comp/user/user.component';
import { UserService } from './shared/user.service';
import { AuthInterceptor } from './shared/auth.Interceptor';

@NgModule({
  declarations: [
    AppComponent,
    MainCompComponent,
    SpyItemsComponent,
    AddItemComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(/*{}*/)
  ],
  providers: [UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
