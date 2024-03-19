import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatSelectModule } from '@angular/material/select';
import { Router } from '@angular/router';
import { RecipeService } from '../../recipe.service';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule, MatChipsModule],
  templateUrl: './create.component.14227.html',
  styleUrl: './create.component.14227.css'
})
export class CreateComponent {

  recipeService = inject(RecipeService); 

  router = inject(Router);

    // Category Object
    category: any;

  cID: number = 0;


  createRecipe: any = {
    name: "",
    description: "",
    ingredients: "",
    instructions: "",
    cookingTimeInMinutes: 0,
    categoryID: 0,
  }


  ngOnInit() {
    this.recipeService.getAllCategories().subscribe((result) => {
      this.category = result
    })
  }


  create() {
    this.createRecipe.categoryID = this.cID
    this.recipeService.create(this.createRecipe).subscribe(result => {
      alert("Recipe Saved")
      this.router.navigateByUrl("home")
    })
  }
}
