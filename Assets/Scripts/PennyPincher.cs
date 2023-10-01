using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PennyPincher : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Image button;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PennyPincher", -1);
        text = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SetText()
    {
        Color copy = button.color;
        if (PlayerPrefs.GetInt("PennyPincher") == -1)
        {
            text.text = "Enable PennyPincher";
            copy.g = 255;
            copy.b = 255;
        }
        else
        {
            text.text = "Disable PennyPincher";     
            copy.g = 0;
            copy.b = 0;
        }
        button.color = copy;
    }

    public void StartPennyPincher()
    {
        int current = PlayerPrefs.GetInt("PennyPincher");
        int next = current * -1;
        PlayerPrefs.SetInt("PennyPincher", next);
        SetText();
    }
}
