using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipePanel : MonoBehaviour
{
    public bool filled;
    public List<string> recipe;
    public List<Sprite> ingredientImages;
    // Start is called before the first frame update
    void Start()
    {
        filled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Create()
    {
        Color copy = gameObject.GetComponent<Image>().color;
        copy.a = 1;
        gameObject.GetComponent<Image>().color = copy;
        int count = 1;

        Image[] panels = gameObject.GetComponentsInChildren<Image>();
        foreach (string ingredient in recipe)
        {
            Image panel = panels[count];
            copy = panel.color;
            copy.a = 1;
            panel.color = copy;
            SetImage(panel, ingredient);
            count++;
        }

        filled = true;
    }

    void SetImage(Image panel, string ingredient)
    {
       if(ingredient == "Tomato")
        {
            panel.sprite = ingredientImages[0];
            panel.transform.localScale = new Vector3(1.25f, 1, 0);
        }
       else if (ingredient == "Onion")
        {
            panel.sprite = ingredientImages[1];
            panel.transform.localScale = new Vector3(1.25f, 1, 0) * 2;
        }
    }

    public void EmptyPanel()
    {
        foreach (Image panel in gameObject.GetComponentsInChildren<Image>())
        {
            Color copy = panel.color;
            copy.a = 0;
            panel.color = copy;
        }
        
        filled = false;
    }

}
