using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutOfSpace : MonoBehaviour
{
    public GameObject gameController;
    private RecipeController recipeController;
    private TextMeshProUGUI text; 
    // Start is called before the first frame update
    void Start()
    {
        recipeController = gameController.GetComponent<RecipeController>();
        text = gameObject.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        Color copy = text.color;
        if (recipeController.recipeCount == recipeController.totalRecipes)
        {
            text.text = "RESTAURANT IS FULL!!!!!!!";
            copy.a = 255;
        }
        else if (recipeController.recipeCount == 0)
        {
            text.text = "Empty";
        }
        else if (recipeController.recipeCount == 1)
        {
            text.text = "Quiet";
        }
        else if (recipeController.recipeCount == 2)
        {
            text.text = "Filling up!";
        }
        else if (recipeController.recipeCount == 3)
        {
            text.text = "Barely any space left!!";
        }
        text.color = copy;
    }
}

