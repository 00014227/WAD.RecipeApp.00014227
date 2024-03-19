import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RecipeService } from '../../recipe.service';
import { RecipeItems } from '../../RecipeItems';
import { MatChipsModule } from '@angular/material/chips';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-delete',
  standalone: true,
  imports: [MatChipsModule, MatCardModule, MatButtonModule],
  templateUrl: './delete.component.14227.html',
  styleUrl: './delete.component.14227.css'
})
export class DeleteComponent {
  deleteRecipe:RecipeItems={
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
  }

  service = inject(RecipeService)
  activateRote = inject(ActivatedRoute)
  router = inject(Router)

  ngOnInit(){
    this.service.getByID(this.activateRote.snapshot.params["id"]).subscribe((result)=>{
      this.deleteRecipe = result
      console.log(result, 'dddddddddddddd')
    });
  }

  onHomeButtonClick(){
    this.router.navigateByUrl("home")
  }
  
  onDeleteButtonClick(id: number) {
    console.log(id); // Log the ID that is being passed
    this.service.delete(id).subscribe(() => {
      alert("Deleted recipe with ID: " + id);
      this.router.navigateByUrl("home");
    });
  }
  
}
