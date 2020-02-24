using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject someName;
    private float difficultyScaler;

    public void CreateNewAsteroid(float x, float y)
    {
        Instantiate(someName, new Vector3(x, y, 0), Quaternion.identity);
    }

    private void MakeRandomAsteroid() {
        int randInt = Random.Range(1, 26);    // random asteroid generated
        if(randInt >= 1 && randInt <= 5)      // Left
            CreateNewAsteroid(Random.Range(-(Globals.VIEW_X_RADIUS + 2), -(Globals.VIEW_X_RADIUS + 1)), Random.Range(-(Globals.VIEW_Y_RADIUS + 1), Globals.VIEW_Y_RADIUS + 1));
        else if(randInt >= 6 && randInt <= 13) // Bottom
            CreateNewAsteroid(Random.Range(-(Globals.VIEW_X_RADIUS + 1), Globals.VIEW_X_RADIUS + 1), Random.Range(-(Globals.VIEW_Y_RADIUS + 2), -(Globals.VIEW_Y_RADIUS + 1)));
        else if(randInt >= 14 && randInt <= 18) // Right
            CreateNewAsteroid(Random.Range(Globals.VIEW_X_RADIUS + 1, Globals.VIEW_X_RADIUS + 2), Random.Range(-(Globals.VIEW_Y_RADIUS + 1), Globals.VIEW_Y_RADIUS + 1));
        else                                  // Top
            CreateNewAsteroid(Random.Range(-(Globals.VIEW_X_RADIUS + 1), Globals.VIEW_X_RADIUS + 1), Random.Range(Globals.VIEW_Y_RADIUS + 1, Globals.VIEW_Y_RADIUS + 2));
    }
    // Start is called before the first frame update
    void Start()
    {
        difficultyScaler = 0;
        // Create asteroids at random locations outside camera view
        for(int i = 0; i < 3; i++)  // Left
            CreateNewAsteroid(Random.Range(-(Globals.VIEW_X_RADIUS + 2), -(Globals.VIEW_X_RADIUS + 1)), Random.Range(-(Globals.VIEW_Y_RADIUS + 1), Globals.VIEW_Y_RADIUS + 1));
        for(int i = 0; i < 4; i++)  // Bottom
            CreateNewAsteroid(Random.Range(-(Globals.VIEW_X_RADIUS + 1), Globals.VIEW_X_RADIUS + 1), Random.Range(-(Globals.VIEW_Y_RADIUS + 2), -(Globals.VIEW_Y_RADIUS + 1)));
        for(int i = 0; i < 3; i++)  // Right
            CreateNewAsteroid(Random.Range(Globals.VIEW_X_RADIUS + 1, Globals.VIEW_X_RADIUS + 2), Random.Range(-(Globals.VIEW_Y_RADIUS + 1), Globals.VIEW_Y_RADIUS + 1));
        for(int i = 0; i < 4; i++)  // Top
            CreateNewAsteroid(Random.Range(-(Globals.VIEW_X_RADIUS + 1), Globals.VIEW_X_RADIUS + 1), Random.Range(Globals.VIEW_Y_RADIUS + 1, Globals.VIEW_Y_RADIUS + 2));
    }

    // Update is called once per frame
    void Update()
    {
      if(!Globals.ON_BEAT && Input.GetKeyDown("space")) { // if offbeat and player presses key down
          MakeRandomAsteroid();
      }
    }
    // 50 times a second
    void FixedUpdate() {
        difficultyScaler += 0.005f;
        int randInt = Random.Range(1, 50 - 25 * Globals.DIFFICULTY - (int)difficultyScaler); // Averages 1 to 2 asteroids per second
        if(randInt <= 1) MakeRandomAsteroid();
    }
}
