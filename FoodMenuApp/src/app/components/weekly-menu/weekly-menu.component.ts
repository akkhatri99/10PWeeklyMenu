import { Component, TemplateRef, ViewChild } from '@angular/core';
import { FoodMenu } from '../../models/FoodMenu';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FoodMenuService } from '../../services/food-menu.service';
import { MatDialog } from '@angular/material/dialog';
import { AddItemDialogComponent } from './add-item-dialog/add-item-dialog.component';
import { MatFormFieldControl } from '@angular/material/form-field';
import { AppComponent } from '../../app.component';
import party from "party-js";

@Component({
  selector: 'app-weekly-menu',
  templateUrl: './weekly-menu.component.html',
  styleUrl: './weekly-menu.component.css',
  providers: [
    { provide: MatFormFieldControl, useExisting: AppComponent}   
  ]
})
export class WeeklyMenuComponent {
  
  @ViewChild('callAPIDialog') callAPIDialog: TemplateRef<any> | any;
  
  foodData: FoodMenu[] = [];

  constructor (private fb: FormBuilder, private foodMenuService: FoodMenuService, public matdialog : MatDialog, private FoodMenuService: FoodMenuService) {}

  addFoodForm : FormGroup = this.fb.group ({
    Item: '',
    Date: Date.UTC,
    Day: '',
    Image: ''
  }); 

  dayValue: any;

  foodMenuAdd : FoodMenu[] = [];

  myColor : 'primary' | 'accent' | 'warn' = 'primary';

  ngOnInit(){
    this.FoodMenuService.getFoodMenuData().subscribe((result: FoodMenu[]) => this.foodData = result);
  }

  openDialog() {
    const dialogRef = this.matdialog.open(AddItemDialogComponent);
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if(val) {
          this.FoodMenuService.getFoodMenuData().subscribe((result: FoodMenu[]) => this.foodData = result);
        }
      }
    })
  }

  like(data: any, event: any){
    data.likeCount++;
    party.confetti(event)
    this.foodMenuService
      .updateLikeCount(data)
      .subscribe((result : any) => this.dayValue = result)
  }

  dislike(data: any, event: any){
    data.dislikeCount++;
    party.confetti(event);
    this.foodMenuService
      .updateDisLikeCount(data)
      .subscribe((result : any) => this.dayValue = result)
  }
}
