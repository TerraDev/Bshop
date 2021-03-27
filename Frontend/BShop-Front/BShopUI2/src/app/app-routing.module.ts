import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ItemPageComponent } from './item/item-page/item-page.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { ProfileComponent } from './user/profile/profile.component';
import { UserItemComponent } from './item/user-item/user-item.component';
import { ItemlistComponent } from './item/itemlist/itemlist.component';

const routes: Routes = [
  { path: 'user/login', component: LoginComponent },
  { path: 'user/register', component: RegisterComponent },
  { path: 'user/profile', component: ProfileComponent },
  { path: 'user/items', component: UserItemComponent },
  { path: 'items', component: ItemlistComponent},
  { path: 'item/num', component: ItemPageComponent},
  { path: '',   redirectTo: '/items' , pathMatch: 'full' }, // redirects
  { path: '**' , component: PageNotFoundComponent } // Wildcard route for a 404 page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
