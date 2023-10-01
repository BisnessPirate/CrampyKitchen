using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewHigh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("PrevHighscore") < PlayerPrefs.GetFloat("Score"))
        {
            Color copy = gameObject.GetComponent<TextMeshProUGUI>().color;
            copy.a = 255;
            gameObject.GetComponent<TextMeshProUGUI>().color = copy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
