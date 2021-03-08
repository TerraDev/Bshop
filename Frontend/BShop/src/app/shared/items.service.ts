import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Items } from './items.model';

@Injectable({
  providedIn: 'root'
})

export class ItemsService {

  constructor(private Http: HttpClient) {}

  readonly PostURL= 'http://localhost:63825/Item/Create';
  readonly GetAllURL= 'http://localhost:63825/Item/All';
  readonly PutURL= 'http://localhost:63825/Item/Update';
  readonly DeleteURL='http://localhost:63825/Item/Delete';
  
  formData: Items = new Items();
  Itemlist: Items[];

  PostItem()
  {
    return this.Http.post(this.PostURL, this.formData);
  }

  PutItem()
  {
    return this.Http.put(this.PutURL + "/" + this.formData.id, this.formData);
  }

  DeleteItem(id:String)
  {
    return this.Http.delete(this.DeleteURL + "/" + id);
  }

  GetAllItems()
  {
    this.Http.get(this.GetAllURL)
    .toPromise()
    .then(res => this.Itemlist = res as Items[]);
  }
}
