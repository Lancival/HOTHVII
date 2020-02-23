using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject someName;
    public void CreateNewAsteroid(float x, float y)
    {
        Instantiate(someName, new Vector3(x, y, 0), Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++) {
          CreateNewAsteroid(Random.Range(-10.0f, 10.0f),Random.Range(-10.0f, 10.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
