import { Component, Input, inject } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';

import { Router } from '@angular/router';
import { RecipeItems } from '../../RecipeItems';
import { RecipeService } from '../../recipe.service';



@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatTableModule, MatButtonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  router = inject(Router)
  items:RecipeItems[]=[];
  recipeService = inject(RecipeService);
  ngOnInit(){
    this.recipeService.getAll().subscribe((result)=>{
      this.items = result;
    });
  }

  displayedColumns: string[] = ['ID', 'Title', 'Description', 'Category Name', 'Cooking Time' ,'Actions'];

  onCreate(){
    console.log("Oncreate Clicked")
    this.router.navigateByUrl("/create")
  }
  onEdit(id:number){
    console.log("Edit: ", id)
    this.router.navigateByUrl("/edit/"+id)
  }
  onDetails(id:number){
    console.log("onDetails: ", id)
    this.router.navigateByUrl("/details/"+id)
  }
  onDelete(id:number){
    console.log("onDelete: ", id)
    this.router.navigateByUrl("/delete/"+id)
  }
}
