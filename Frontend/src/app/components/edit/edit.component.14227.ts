import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { RecipeService } from '../../recipe.service';
import { ActivatedRoute, Router } from '@angular/router';
import { RecipeItems } from '../../RecipeItems';


function findIndexById(jsonArray: any[], indexToFind: number): number {
  return jsonArray.findIndex((item) => item.id === indexToFind)
}

@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [MatSelectModule, MatInputModule, MatButtonModule, FormsModule, MatFormFieldModule],
  templateUrl: './edit.component.14227.html',
  styleUrl: './edit.component.14227.css'
})

export class EditComponent implements OnInit {
  recipeService = inject(RecipeService)
  activatedRoute = inject(ActivatedRoute)
  router = inject(Router);
  editRecipe: RecipeItems = {
    id: 0,
    name: "",
    description: "",
    ingredients: "",
    instructions: "",
    cookingTimeInMinutes: 0,
    createdAt: new Date,
    categoryID: 0,
    category: {
      id: 0,
      name: ""
    }
  };

  categoryObject: any; // Category Object for listing
  selected: any // if any selected by default
  cID: number = 0;// category ID To inject to
  ngOnInit() {
    this.recipeService.getByID(this.activatedRoute.snapshot.params["id"]).subscribe(result => {
      this.editRecipe = result;
      this.selected = this.editRecipe.categoryID;
    });
    this.recipeService.getAllCategories().subscribe((result) => {
      this.categoryObject = result;
    });
  }

  toHome(){
    this.router.navigateByUrl("home")
  }

  edit() {
    this.editRecipe.categoryID = this.cID;
    this.editRecipe.category = this.categoryObject[findIndexById(this.categoryObject, this.cID)];
    this.recipeService.edit(this.editRecipe).subscribe(res=>{
      alert("Changes has been updated")
      this.router.navigateByUrl("home");
    })
  }
}
