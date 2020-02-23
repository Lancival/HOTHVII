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
        CreateNewAsteroid(0,0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
