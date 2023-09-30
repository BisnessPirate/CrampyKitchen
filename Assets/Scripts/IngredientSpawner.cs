using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public List<GameObject> spawnable = new List<GameObject>();
    public float spawnTimer;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            timer += Time.deltaTime;

            if(timer > spawnTimer)
            {
                timer = 0;
                Spawn();
            }
        }
    }

    void Spawn()
    {
        
        GameObject newTomato = Instantiate(spawnable[Random.Range(0,spawnable.Count)], transform);
    }

}
