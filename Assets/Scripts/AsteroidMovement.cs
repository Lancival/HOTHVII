using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody2D asteroid;
    private Vector2 position;

    private float moveSpeed;
    private float rotationSpeed;
    private float moveAngle;

    // Start is called before the first frame update
    void Start()
    {
        asteroid = gameObject.GetComponent<Rigidbody2D>();
        position = asteroid.position;

        moveSpeed = Random.Range(0.5f, 4f);         // velocity from 0.5 to 4
        rotationSpeed = Random.Range(-1f, 1f);      // rotation speed from -1 to 1

        // Determine random moveAngle based on asteroid position
        moveAngle = Random.Range(0, Mathf.PI / 2);
        if(position.x < 0 && position.y < 0) {}
        else if (position.x > 0 && position.y < 0) moveAngle += Mathf.PI / 2;
        else if (position.x > 0 && position.y > 0) moveAngle += Mathf.PI;
        else moveAngle += Mathf.PI * 3f/2f;

        // veclocity based on moveSpeed and moveAngle
        asteroid.velocity = new Vector2(moveSpeed * Mathf.Cos(moveAngle), moveSpeed * Mathf.Sin(moveAngle));

        asteroid.rotation = moveAngle;  // start off with random angle of rotation
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        asteroid.rotation += rotationSpeed; // change rotation by rotationSpeed

        if(position.magnitude > 18) Destroy(gameObject);
    }
}
