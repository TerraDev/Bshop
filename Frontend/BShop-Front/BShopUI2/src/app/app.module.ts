import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatToolbarModule } from '@angular/material/toolbar';

import { ReactiveFormsModule} from '@angular/forms'
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select'
import { MatCheckboxModule} from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatDialogModule } from '@angular/material/dialog'

import { AppComponent } from './app.component';
import { ItemPageComponent } from './item/item-page/item-page.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { ProfileComponent } from './user/profile/profile.component';
import { ItemComponent } from './item/item.component';
import { ItemlistComponent } from './item/itemlist/itemlist.component';
import { UserItemComponent } from './item/user-item/user-item.component';
import { AddItemDialogComponent } from './item/user-item/add-item-dialog/add-item-dialog.component';

import { ToastrModule } from 'ngx-toastr';
import { HttpClientModule } from '@angular/common/http';
import { UpdateItemDialogComponent } from './item/item-page/update-item-dialog/update-item-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    ItemPageComponent,
    PageNotFoundComponent,
    UserComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
    ItemComponent,
    ItemlistComponent,
    UserItemComponent,
    AddItemDialogComponent,
    UpdateItemDialogComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatDialogModule,
    ToastrModule.forRoot(), // ToastrModule added
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
