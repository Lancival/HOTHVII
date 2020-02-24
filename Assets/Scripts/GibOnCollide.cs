using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibOnCollide : MonoBehaviour
{
    public int value;

    void OnTriggerEnter2D(Collider2D collider)
    {

        //Instantiate(sound, transform.position, transform.rotation);
        //ManageGame.score+= value;
        if(gameObject.name == "Player") { // if colliding object is a player
            Globals.LIVES--;              // subtract a life
            Debug.Log("lose life");
            Debug.Log(Globals.LIVES + " lives left");
            if(Globals.LIVES == 0) { Destroy(gameObject); } // Destroy player once 0 lives
        } else {
            Destroy(gameObject);
        }
    }
}
