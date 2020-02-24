using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;

    private bool[] powerUps = new bool[3];
    private int bulletType;
    private Rigidbody2D playerBody;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        bulletType = 0;
        for(int i = 0; i < 3; i++) powerUps[i] = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Vector2 tempPos = transform.position;
            float currentAngle = playerBody.rotation * Mathf.Deg2Rad;
            Vector2 offset = new Vector2(-Mathf.Sin(currentAngle), Mathf.Cos(currentAngle));
            Instantiate(bullet, tempPos+offset, transform.rotation);
            if (!Globals.ON_BEAT)
            {
                Globals.COMBOS = 0;
                Debug.Log("offbeat");
            }
            else
            {
                Globals.COMBOS++;
                Debug.Log("onbeat");
            }

            // COMBO and PowerUp logic tree
            if(Globals.COMBOS < 10) {
                powerUps[0] = powerUps[1] = powerUps[2] = false;
            } else if(Globals.COMBOS >= 10 && Globals.COMBOS < 25) {
                powerUps[0] = true;
            } else if(Globals.COMBOS >= 25 && Globals.COMBOS < 50) {
                powerUps[0] = powerUps[1] = true;
            } else {
                powerUps[0] = powerUps[1] = powerUps[2] = true;
            }

        }
    }
}
