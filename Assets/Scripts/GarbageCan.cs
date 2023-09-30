using UnityEngine;

public class GarbageCan : MonoBehaviour
{
    public float cost;
    public GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<RecipeController>().score -= cost;
        Destroy(collision.gameObject);
    }
}
