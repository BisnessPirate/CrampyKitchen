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
            
            copy.a = 255;
        }
        else
        {
            copy.a = 0;
        }
        text.color = copy;
    }
}

