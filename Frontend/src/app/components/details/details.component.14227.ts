import { Component, inject } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { ActivatedRoute } from '@angular/router';
import { RecipeService } from '../../recipe.service';
import { RecipeItems } from '../../RecipeItems';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [MatCardModule, MatChipsModule],
  templateUrl: './details.component.14227.html',
  styleUrl: './details.component.14227.css'
})
export class DetailsComponent {
    detailRecipe:RecipeItems = {
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

serviceRecipe = inject(RecipeService)

activatedRoute = inject(ActivatedRoute)

ngOnInit(){
  // an ID coming from URL. We have replaced it with ID in GetBy ID
  // this.activatedRoute.snapshot.params["id"]
  
  this.serviceRecipe.getByID(this.activatedRoute.snapshot.params["id"]).subscribe((resultedItem)=>{
  this.detailRecipe=resultedItem  
  });
}
}