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
        // Create asteroids at random locations outside camera view
        for(int i = 0; i < 2; i++)  // Left
            CreateNewAsteroid(Random.Range(-(Globals.VIEW_X_RADIUS + 2), -(Globals.VIEW_X_RADIUS + 1)), Random.Range(-(Globals.VIEW_Y_RADIUS + 1), Globals.VIEW_Y_RADIUS + 1));
        for(int i = 0; i < 4; i++) // Bottom
            CreateNewAsteroid(Random.Range(-(Globals.VIEW_X_RADIUS + 1), Globals.VIEW_X_RADIUS + 1), Random.Range(-(Globals.VIEW_Y_RADIUS + 2), -(Globals.VIEW_Y_RADIUS + 1)));
        for(int i = 0; i < 2; i++)  // Right
            CreateNewAsteroid(Random.Range(Globals.VIEW_X_RADIUS + 1, Globals.VIEW_X_RADIUS + 2), Random.Range(-(Globals.VIEW_Y_RADIUS + 1), Globals.VIEW_Y_RADIUS + 1));
        for(int i = 0; i < 4; i++) // Top
            CreateNewAsteroid(Random.Range(-(Globals.VIEW_X_RADIUS + 1), Globals.VIEW_X_RADIUS + 1), Random.Range(Globals.VIEW_Y_RADIUS + 1, Globals.VIEW_Y_RADIUS + 2));
    }

    // Update is called once per frame
    void Update()
    {

      //if(!Globals.ON_BEAT) CreateNewAsteroid
    }
}
