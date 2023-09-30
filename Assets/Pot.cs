using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public List<GameObject> Ingredients = new List<GameObject>(); // We probably want to change this to ingredients. And empty it out once we fulfill a recipe!
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ingredients.Add(collision.gameObject);
    }

    private void CheckIngredient()
    {

    }
}
