import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Items } from 'src/app/shared/items.model';
import { ItemsService } from 'src/app/shared/items.service';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
})
export class AddItemComponent implements OnInit {

  constructor(public service:ItemsService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm): void
  {
    if(this.service.formData.id=='')
    this.InsertRecord(form);
    else
    this.UpdateRecord(form);
  }

  InsertRecord(form: NgForm)
  {
    this.service.PostItem().subscribe(
      res => {
        this.resetForm(form);
        this.service.GetAllItems();
        this.toastr.success('Submitted successfully','Item Submit');
      },
      err => { console.log(err); }
    );
  }

  UpdateRecord(form: NgForm)
  {
    this.service.PutItem().subscribe(
      res => {
        this.resetForm(form);
        this.service.GetAllItems();
        this.toastr.info('Updated successfully','Item edited');
      },
      err => { console.log(err); }
    );
  }

  resetForm(form: NgForm): void
  {
    form.form.reset();
    this.service.formData = new Items();
  }


}
