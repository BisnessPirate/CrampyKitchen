using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverUIController : MonoBehaviour
{
    public GameObject ServedText;
    public GameObject ScoreText;
    public GameObject HighscoreText;
    public GameObject NewHighText;
    // Start is called before the first frame update
    void Start()
    {
        float score = PlayerPrefs.GetFloat("Score");
        float highScore = PlayerPrefs.GetFloat("HighScore");

        ServedText.GetComponent<TextMeshProUGUI>().text = "Served: " + PlayerPrefs.GetInt("Served").ToString();
        ScoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();


        if (score > highScore)
        {
            PlayerPrefs.SetFloat("PrevHighScore", highScore);
            PlayerPrefs.SetFloat("HighScore", score);

            Color copy = NewHighText.GetComponent<TextMeshProUGUI>().color;
            copy.a = 255;
            NewHighText.GetComponent<TextMeshProUGUI>().color = copy;

            HighscoreText.GetComponent<TextMeshProUGUI>().text = "Previous HighScore: " + PlayerPrefs.GetFloat("PrevHighScore").ToString();
        }
        else
        {
            HighscoreText.GetComponent<TextMeshProUGUI>().text = "HighScore: " + highScore.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
