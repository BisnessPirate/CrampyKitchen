using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Collections;
using UnityEngine;

public class CookingBar : MonoBehaviour
{
    public GameObject Pot;
    private float timer;
    private float maxTime;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = Pot.GetComponent<Pot>().cookingTime;
        maxTime = Pot.GetComponent<Pot>().toCookTime;
        SetBar();
    }
    

    void SetBar()
    {
        if(timer  <= maxTime)
        {
            transform.localScale = new Vector3(timer/maxTime * 0.9f, 0.8f, 0f);
        }
        else if (timer <= 2 * maxTime) 
        {
            transform.localScale = new Vector3((timer / maxTime - 1) * 0.9f, 0.8f, 0f);
            Color newColor = new Color(255,0,0);
            sprite.color = newColor;
        }
        else
        {
            Color newColor = new Color(0, 0, 0);
            sprite.color = newColor;
        }
        
    }

    public void ResetBar()
    {
        transform.localScale = new Vector3(0.1f, 0.8f, 0f);
        Color newColor = new Color(0, 0, 255);
        sprite.color = newColor;
    }

}
