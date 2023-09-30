using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RecipeController : MonoBehaviour
{
    public List<GameObject> ingredients = new List<GameObject>();
    public List<List<string>> recipes = new List<List<string>>();
    public List<RecipePanel> recipePanels = new List<RecipePanel>();

    public int totalRecipes;
    public int recipeCount;

    public float recipeTimer;

    public int score;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        CreateRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(recipeCount < totalRecipes)
        {
            //We do a double if statement instead of one because we want to stop the timer once we have the max, for now.
            timer += Time.deltaTime;
            if (timer > recipeTimer) 
            {
                AddRecipe(CreateRecipe());
                timer = 0;
            }
            
        }
    }
    public void RemovePanel(List<string> recipe)
    {

        foreach (RecipePanel panel in recipePanels)
        {
            if (panel.filled & panel.recipe == recipe)
            {
                panel.EmptyPanel();
                break;
            }
        }
    }

    private void AddPanel(List<string> recipe)
    {
        foreach (RecipePanel panel in recipePanels)
        {
            if (!panel.filled)
            {
                panel.recipe = recipe;
                panel.Create();
                break;
            }
        }

    }
    public void AddRecipe(List<string> recipe)
    {
        recipes.Add(recipe);
        AddPanel(recipe);
        recipeCount++;
    }

    private List<string> CreateRecipe()
    {
        List<string> recipe = new List<string>();
        int recipeLength;
        recipeLength = Random.Range(1, 4);
        int count = 0;
        while (count < recipeLength)
        {
            recipe.Add(ingredients[Random.Range(0, ingredients.Count)].name);
            count++;
        }

        return recipe;
    }

    public void RemoveRecipe(List<string> recipe)
    {

        RemovePanel(recipe);
        recipes.Remove(recipe);
        recipeCount--;

    }
}
