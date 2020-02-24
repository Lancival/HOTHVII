using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;

    //0 is trident, 1 is penetration, 2 is combo saver
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
            if (Globals.ON_BEAT)
            {
                Globals.COMBOS++;
            }
            else
            {
                if (powerUps[2])
                {
                    powerUps[2] = false;
                }
                else
                {
                    Globals.COMBOS = 0;
                    powerUps[0] = powerUps[1] = powerUps[2] = false;
                }
                Globals.COMBOS = 0;
                powerUps[0] = powerUps[1] = powerUps[2] = false;
                Globals.SCORE -= 5;
            }
            // COMBO and PowerUp logic tree
            if (Globals.COMBOS < 10)
            {
            }

            else if (Globals.COMBOS >= 10 && Globals.COMBOS < 25)
            {
                powerUps[0] = true;
            }
            else if (Globals.COMBOS >= 25 && Globals.COMBOS < 50)
            {
                powerUps[0] = powerUps[1] = true;
            }
            else
            {
                powerUps[0] = powerUps[1] = powerUps[2] = true;
            }
            Shot(0f);
            if (powerUps[0])
            {
                Shot(-30f);
                Shot(30f);
            }
        }
    }
    
    void Shot(float rotationVal)
    {
        Vector2 tempPos = transform.position;
        float currentAngle = (playerBody.rotation+rotationVal) * Mathf.Deg2Rad;
        Vector2 offset = new Vector2(-Mathf.Sin(currentAngle), Mathf.Cos(currentAngle));
        Instantiate(bullet, tempPos + offset, Quaternion.Euler(0,0,currentAngle*Mathf.Rad2Deg));
    }

    public void PowerUpSet(int index)
    {
        if (index < 0 || index > 3) return;
        powerUps[index] = true;
    }

    public bool PowerUpVal(int index)
    {
        if (index < 0 || index > 3) return;
        return powerUps[index];
    }
}
