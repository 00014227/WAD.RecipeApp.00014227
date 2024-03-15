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
    return this.httpClient.get<RecipeItems[]>("https://localhost:7031/api/RecipeBook");
  }
}
