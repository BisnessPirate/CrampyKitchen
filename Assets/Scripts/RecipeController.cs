using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RecipeController : MonoBehaviour
{
    public List<GameObject> ingredients = new List<GameObject>();
    public List<List<string>> recipes = new List<List<string>>();
    public List<RecipePanel> recipePanels = new List<RecipePanel>();

    public int totalRecipes;
    public int recipeCount;

    public float recipeTimer;

    public float score;
    public int served;
    public float scoreLoss;

    public float difficultyIncrease;

    private float timer;
    private bool increasedDifficulty;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("PennyPincher") == -1)
        {
            scoreLoss = 0;
        }
        increasedDifficulty = true;
        AddRecipe(CreateRecipe());

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        NextRecipe();
        IncreaseDifficulty();
    }

    private void IncreaseDifficulty()
    {
        if (served % 4 == 0 && !increasedDifficulty)
        {
            increasedDifficulty = true;
            recipeTimer -= difficultyIncrease;
        }
        else if(served % 4 == 1)
        {
            increasedDifficulty = false;
        }


    }

    private void NextRecipe()
    {
        if (recipeCount < totalRecipes)
        {
            //We do a double if statement instead of one because we want to stop the timer once we have the max, for now.
            if (timer > recipeTimer)
            {
                AddRecipe(CreateRecipe());
                timer = 0;
            }

        }
        else if (timer > recipeTimer)
        {
            GameOver();
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

    public void LowerScore()
    {
        score -= scoreLoss;
    }

    private void GameOver()
    {
        PlayerPrefs.SetFloat("Score", score);
        PlayerPrefs.SetInt("Served", served);
        //if (score > PlayerPrefs.GetFloat("HighScore"))
        //{
        //    PlayerPrefs.SetFloat("PrevHighScore", PlayerPrefs.GetFloat("HighScore"));
        //    PlayerPrefs.SetFloat("HighScore", score);
        //}
        //if (served > PlayerPrefs.GetInt("HighServed"))
        //{
        //    PlayerPrefs.SetInt("HighServed", served);
        //}
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
