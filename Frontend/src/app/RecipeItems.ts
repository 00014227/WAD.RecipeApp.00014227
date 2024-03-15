export interface RecipeItems{
    id: number,
    name: string,
    description: string,
    ingredients: string,
    instructions: string,
    cookingTimeInMinutes: number,
    createdAt: Date,
    categoryID: number,
    category: {
      id: number,
      name: string
    }
}