using UnityEngine;

public class GarbageCan : MonoBehaviour
{
    public float cost;
    public GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("PennyPincher") == -1)
        {
            cost = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<RecipeController>().score -= cost;
        Destroy(collision.gameObject);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
