using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public List<GameObject> Ingredients = new List<GameObject>(); // We probably want to change this to ingredients. And empty it out once we fulfill a recipe!
    public float cookingTime;
    public float toCookTime;
    public GameObject gameController;
    private List<List<string>> recipes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cook();
    }
    public void Serve()
    {
        if (cookingTime > toCookTime && cookingTime < 2 * toCookTime)
        {
            CheckIngredients();
        }
    }
    private void Cook()
    {
        if (Ingredients.Count != 0)
        {
            cookingTime += Time.deltaTime;
        }
        // We also check if we overcook
        //if (cookingTime >= 2 * toCookTime)
        //{
        //    CleanPot(); 
        //}
    }

    private void CleanPot()
    {
        // This fully resets the pot.
        //We might want to make cleaning the pot a button later. Not for now.
        toCookTime = 0;
        cookingTime = 0;
        foreach (GameObject ingredient in Ingredients)
        {
            //Ingredients.Remove(ingredient);
            Destroy(ingredient);
        }
        Ingredients = new List<GameObject>();
        gameObject.GetComponentInChildren<CookingBar>().ResetBar();
    }

    public void TrashPot()
    {
        CleanPot();
        gameController.GetComponent<RecipeController>().score -= 8 * gameController.GetComponent<RecipeController>().scoreLoss;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ingredient")
        {
            Ingredients.Add(collision.gameObject);
            toCookTime += collision.gameObject.GetComponent<Ingredient>().cookingTime;
        }
        gameObject.GetComponents<AudioSource>()[1].Play();
    }

    /// <summary>
    /// Here we compare the ingredients inside of the pot if it done cooking. 
    /// First we check if the pot is done cooking
    /// Then we loop throug all recipes
    /// Then we loop through all ingredients in the pot
    /// If an ingredient is in the recipe, we remove it from the recipe
    /// If at the end the recipe is empty, we have found the first recipe we completed. Thus we remove it from the recipe list and break out of the loop.
    /// </summary>
    private void CheckIngredients()
    {
        if(cookingTime >= toCookTime)
        {
            recipes = gameController.GetComponent<RecipeController>().recipes;
            foreach (List<string> recipe in recipes)
            {
                if (Ingredients.Count == recipe.Count)
                {
                    int count = 0;
                    List<string> copyRecipe = recipe;
                    foreach (GameObject ingredient in Ingredients)
                    {
                        name = ingredient.GetComponent<Ingredient>().ingredientName;
                        if (copyRecipe.Contains(name))
                        {
                            copyRecipe.Remove(name);
                        }

                        count++;
                        if (copyRecipe.Count == 0)
                        {
                            // we want break out if we still have more ingreadients left in the pot than the recipe required.
                            // Afterall, if our customer wants 2 tomatoes, 3 is too many.
                            if(count != Ingredients.Count)
                            {
                                break;
                            }

                        }
                    }
                    //We have this outside of the inner forloop so that the break happens neatly, otherwise unity screams at us.
                    if (copyRecipe.Count == 0)
                    {
                        gameController.GetComponent<RecipeController>().score += Ingredients.Count;
                        gameController.GetComponent<RecipeController>().served += 1;
                        gameController.GetComponent<RecipeController>().RemoveRecipe(recipe);
                        CleanPot();
                        break;
                    }
                }

            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponents<AudioSource>()[0].Play();
    }
}
