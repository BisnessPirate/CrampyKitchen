using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float score = PlayerPrefs.GetFloat("Score");
        if (score > PlayerPrefs.GetFloat("HighScore"))
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "HighScore: " + PlayerPrefs.GetFloat("PrevHighScore").ToString();
        }
        else
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "HighScore: " + PlayerPrefs.GetFloat("Highscore").ToString();
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
