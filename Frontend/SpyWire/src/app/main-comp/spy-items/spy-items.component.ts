import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Items } from 'src/app/shared/items.model';
import { ItemsService } from 'src/app/shared/items.service';

@Component({
  selector: 'app-spy-items',
  templateUrl: './spy-items.component.html',
  styleUrls: ['./spy-items.component.css']
})

export class SpyItemsComponent implements OnInit {

  constructor(public itemService: ItemsService,private toastr: ToastrService) { }

  ngOnInit(): void {
    this.itemService.GetAllItems();
  }

  PopulateForm(SelectedItem: Items)
  {
    this.itemService.formData = Object.assign({},SelectedItem) ;
  }

  onDelete(id:String)
  {
    if(confirm('Are you sure you want to delete this item?'))
    {
      this.itemService.DeleteItem(id)
      .subscribe(
        res => {
          this.itemService.GetAllItems();
          this.toastr.warning("Deleted successfully","Item removed");
        },
        err => {console.log(err)}
      )
    }
  }
}
