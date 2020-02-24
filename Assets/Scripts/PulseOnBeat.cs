using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseOnBeat : MonoBehaviour
{
    public GameObject readyIndicator;

    private Rigidbody2D playerBody;
    private bool hasPulsed;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        hasPulsed = false;
        /*Vector2 tempPos = transform.position;
        float currentAngle = playerBody.rotation * Mathf.Deg2Rad;
        Vector2 offset = new Vector2(-Mathf.Sin(currentAngle), Mathf.Cos(currentAngle));
        Instantiate(readyIndicator, tempPos + offset, transform.rotation);*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        readyIndicator.transform.position = playerBody.transform.position;
        if (Globals.ON_BEAT && !hasPulsed)
        {
            hasPulsed = true;
            Vector2 tempPos = transform.position;
            float currentAngle = playerBody.rotation * Mathf.Deg2Rad;
            Vector2 offset = new Vector2(-Mathf.Sin(currentAngle), Mathf.Cos(currentAngle)) * 0.3f;
            Instantiate(readyIndicator, tempPos + offset, transform.rotation);

            /*Vector2 tempPos = transform.position;
            float currentAngle = playerBody.rotation * Mathf.Deg2Rad;
            Vector2 offset = new Vector2(-Mathf.Sin(currentAngle), Mathf.Cos(currentAngle));
            readyIndicator.transform.position = tempPos + offset;
            readyIndicator.transform.rotation = transform.rotation;*/
        }
        else if (!Globals.ON_BEAT)
        {
            //readyIndicator.
            hasPulsed = false;
        }
    }
}
