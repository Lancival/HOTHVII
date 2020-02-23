using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{
    public float moveForce; // force based movement, adds to the 'space' feel
    public float rotationSpeed; // should rotation be force-based? causes player to think about compensation
    private Rigidbody2D playerBody;

    private float horizInput;
    private float vertiInput;
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
        direction = new Vector2(-Mathf.Sin(currentAngle), Mathf.Cos(currentAngle));
        if(vertiInput == 1)
            playerBody.AddForce(direction * moveForce);
        playerBody.rotation += rotationSpeed * horizInput * -1;
    }
}
