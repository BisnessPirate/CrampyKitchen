using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public GameObject toolTip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPoint()
    {
        Color copy = toolTip.GetComponent<Image>().color;
        copy.a = 255;
        toolTip.GetComponent<Image>().color = copy;


    }

}
