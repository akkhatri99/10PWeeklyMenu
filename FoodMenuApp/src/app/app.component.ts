import { Component } from '@angular/core';
import { FoodMenuService } from './services/food-menu.service';
import { FoodMenu } from './models/FoodMenu';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'FoodMenuApp';

  constructor() {}
}
