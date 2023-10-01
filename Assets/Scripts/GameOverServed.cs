using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverServed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Served: " + PlayerPrefs.GetInt("Served").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
