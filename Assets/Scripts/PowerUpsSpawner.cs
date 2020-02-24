using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsSpawner : MonoBehaviour
{
    [SerializeField] GameObject firstPowerUp;
    [SerializeField] GameObject secondPowerUp;
    [SerializeField] GameObject thirdPowerUp;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()

        int randInt = Random.Range(1, 100 + 50 * Globals.DIFFICULTY); // Averages 1 powerUp every 2 to 4 seconds
        if(randInt == 1) {
            float x = Random.Range(-Globals.VIEW_X_RADIUS, Globals.VIEW_X_RADIUS);
            float y = Random.Range(-Globals.VIEW_Y_RADIUS, Globals.VIEW_Y_RADIUS);
            switch(Random.Range(1, 3)) {
              case 1:
                Instantiate(firstPowerUp, new Vector3(x, y, 0), Quaternion.identity);
                break;
              case 2:
                Instantiate(secondPowerUp, new Vector3(x, y, 0), Quaternion.identity);
                break;
              case 3:
                Instantiate(thirdPowerUp, new Vector3(x, y, 0), Quaternion.identity);
                break;
            }
        }
    }
}
