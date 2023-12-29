import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FoodMenu } from '../models/FoodMenu';
import { environment } from '../../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class FoodMenuService {

  constructor(private http: HttpClient) { }

  GetWeeklyURI : string = "GetWeeklyData";

  AddOneDayData : string = "AddOneData";

  UpdateLikeCount : string = "UpdateLike";

  UpdateDisLikeCount : string = "UpdateDisLike";


  public getFoodMenuData(): Observable<FoodMenu[]>{
    return this.http.get<FoodMenu[]>(`${environment.apiUrl + this.GetWeeklyURI}`)
  }

  public addFoodMenu(food: FoodMenu): Observable<FoodMenu[]> {
    return this.http.put<FoodMenu[]>(`${environment.apiUrl}` + this.AddOneDayData , food);
  }
  public updateLikeCount(food : any): Observable<FoodMenu[]>{
    return this.http.put<FoodMenu[]>(`${environment.apiUrl}` + this.UpdateLikeCount, food);
  }
  public updateDisLikeCount(food : any): Observable<FoodMenu[]>{
    debugger
    return this.http.put<FoodMenu[]>(`${environment.apiUrl}` + this.UpdateDisLikeCount, food);
  }
}
