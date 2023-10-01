using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public GameObject gameController;
    private RecipeController recipeController;

    private TextMeshProUGUI main;
    private TextMeshProUGUI score;
    
    // Start is called before the first frame update
    void Start()
    {
        main = GetComponentsInChildren<TextMeshProUGUI>()[0];
        score = GetComponentsInChildren<TextMeshProUGUI>()[1];
        recipeController = gameController.GetComponent<RecipeController>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUpdate();
    }

    private void ScoreUpdate()
    {
        score.text = recipeController.score.ToString();
    }
}
