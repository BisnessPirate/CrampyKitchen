using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string ingredientName;
    public float cookingTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
