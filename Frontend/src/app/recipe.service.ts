import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { RecipeItems } from './RecipeItems';


@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  httpClient=inject(HttpClient);

  constructor() { }

  getAll(){
    return this.httpClient.get<RecipeItems[]>("https://localhost:7031/api/RecipeBookController_00014227    ");
  };

  getByID(id:number){
    return this.httpClient.get<RecipeItems>("https://localhost:7031/api/RecipeBookController_00014227/id?id=" + id)
  }

  create(item: RecipeItems){
    return this.httpClient.post<RecipeItems>("https://localhost:7031/api/RecipeBookController_00014227", item)
  
  }

  edit(item: RecipeItems){
    return this.httpClient.put<RecipeItems>("https://localhost:7031/api/RecipeBookController_00014227/", item)
  }

  getAllCategories(){
    return this.httpClient.get<RecipeItems[]>("https://localhost:7031/api/CategoryController_00014227")
  };

  delete(id:number) {
    return this.httpClient.delete("https://localhost:7031/api/RecipeBookController_00014227/" + id)
  }
}
