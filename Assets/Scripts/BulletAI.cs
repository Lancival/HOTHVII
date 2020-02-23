using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour
{
    public float speed;
    private Rigidbody2D playerBody;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        float currentAngle = playerBody.rotation * Mathf.Deg2Rad;
        playerBody.velocity = new Vector2(-Mathf.Sin(currentAngle) * speed, Mathf.Cos(currentAngle) * speed);
    }
}
