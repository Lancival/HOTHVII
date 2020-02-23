using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    Rigidbody2D asteroid;

    private float moveVelocity;
    private float rotationSpeed;
    private float moveAngle;

    // Start is called before the first frame update
    void Start()
    {
        asteroid = gameObject.GetComponent<Rigidbody2D>();

        moveVelocity = Random.Range(0.5f, 4f);
        rotationSpeed = Random.Range(-1f, 1f);
        moveAngle = Random.Range(0, Mathf.PI * 2);

        asteroid.velocity = new Vector2(moveVelocity * Mathf.Cos(moveAngle), moveVelocity * Mathf.Sin(moveAngle));
        asteroid.rotation = moveAngle;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        asteroid.rotation += rotationSpeed;
    }
}
