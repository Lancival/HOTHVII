using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{
    public float moveForce; // force based movement, adds to the 'space' feel
    public float rotationSpeed; // should rotation be force-based? causes player to think about compensation
    //public float frictionForce;
    private Rigidbody2D playerBody;

    private float horizInput;
    private float vertiInput;
    private float BORDER = 0.1f;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        direction = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        horizInput = Input.GetAxis("Horizontal");
        vertiInput = Input.GetAxis("Vertical");
        //direction = new Vector2(horizInput, vertiInput);
    }

    void FixedUpdate()
    {
        float currentAngle = playerBody.rotation * Mathf.Deg2Rad;
        //Vector2 friction = playerBody.velocity * -frictionForce;
        direction = new Vector2(-Mathf.Sin(currentAngle), Mathf.Cos(currentAngle));
        if(vertiInput == 1)
            playerBody.AddForce(direction * moveForce);
        playerBody.rotation += rotationSpeed * horizInput * -1;
        //playerBody.velocity += friction;
        //Debug.Log(playerBody.position);

        float playerX = playerBody.position.x;
        float playerY = playerBody.position.y;
        bool willWrap = false;
        if (playerX > 10 + BORDER || playerX < -10 - BORDER)
        {
            playerX = playerX * -1;
            if (playerX > 0) playerX -= BORDER;
            else playerX += BORDER;
            willWrap = true;
        }
        if (playerY > 5 + BORDER || playerY < -5 - BORDER)
        {
            playerY = playerY * -1;
            if (playerY > 0) playerY -= BORDER;
            else playerY += BORDER;
            willWrap = true;
        }

        if (willWrap) {
            playerBody.MovePosition(new Vector2(playerX, playerY));
        }
    }
}
