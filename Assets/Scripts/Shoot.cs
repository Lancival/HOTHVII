using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;

    private int bulletType;
    private Rigidbody2D playerBody;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        bulletType = 0;
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

            if(Globals.COMBOS >= 10)
            {
                Vector2 offset2 = offset * 0.5f;
                Instantiate(bullet, tempPos + offset2, transform.rotation);
            }
        }
    }
}
