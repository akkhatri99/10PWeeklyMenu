import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FoodMenuService } from '../../../services/food-menu.service';

@Component({
  selector: 'app-add-item-dialog',
  templateUrl: './add-item-dialog.component.html',
  styleUrl: './add-item-dialog.component.css'
})
export class AddItemDialogComponent implements OnInit {

  constructor(private Ref: MatDialogRef<AddItemDialogComponent>, private fb : FormBuilder, @Inject(MAT_DIALOG_DATA) public data: any, private foodMenuService: FoodMenuService) { }

  isFieldDisabled : boolean = true;

  menuForm: FormGroup = this.fb.group({
    Item: '',
    Day: '',
    Date: Date,
    Image: ''
  })

  selectedDate: any;
  dayValue: any;

  ngOnInit(): void {
    this.menuForm.patchValue(this.data);
  }

  onDateSelected(event: any): void {
    this.selectedDate = event.value;
    if (this.selectedDate) {
      const options = { weekday: 'long' };
      this.dayValue = this.selectedDate.toLocaleDateString('en-US', options);
    }
  }

  onFormSubmit() {
    if(this.menuForm.valid){
      // if(this.data) {
        this.foodMenuService.addFoodMenu(this.menuForm.value).subscribe({
          next: (val: any) => {
            this.Ref.close(true);
          }
        })
    }
  }
}
