using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseAI : MonoBehaviour
{
    public float speed;
    private GameObject player;
    private SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        Color temp = spriteR.color;
        temp.a = 0;
        spriteR.color = temp;
    }

    void Update()
    {
        if (Globals.ON_BEAT)
        {
            Color temp = spriteR.color;
            temp.a+=10;
            spriteR.color = temp;
            Vector2 tempPos = player.transform.position;
            float currentAngle = player.GetComponent<Rigidbody2D>().rotation * Mathf.Deg2Rad;
            Vector2 offset = new Vector2(-Mathf.Sin(currentAngle), Mathf.Cos(currentAngle)) * 0.3f;
            transform.SetPositionAndRotation(tempPos + offset, player.transform.rotation);
        }
        else
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown("space"))
        {
            Destroy(gameObject);
        }
    }
}
