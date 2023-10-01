using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ServedText : MonoBehaviour
{
    public GameObject gameController;
    private RecipeController recipeController;

    private TextMeshProUGUI main;
    private TextMeshProUGUI served;

    // Start is called before the first frame update
    void Start()
    {
        main = GetComponentsInChildren<TextMeshProUGUI>()[0];
        served = GetComponentsInChildren<TextMeshProUGUI>()[1];
        recipeController = gameController.GetComponent<RecipeController>();
    }

    // Update is called once per frame
    void Update()
    {
        ServeUpdate();
    }

    private void ServeUpdate()
    {
        served.text = recipeController.served.ToString();
    }
}
