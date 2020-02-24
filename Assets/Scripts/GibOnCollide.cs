using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibOnCollide : MonoBehaviour {
    [SerializeField] private int baseScore;

    void OnTriggerEnter2D(Collider2D collider) {

        //Instantiate(sound, transform.position, transform.rotation);
        if(gameObject.name == "Player") { // if colliding object is a player
            Globals.LIVES--;              // subtract a life
            Debug.Log("lose life");
            Debug.Log(Globals.LIVES + " lives left");
            if(Globals.LIVES == 0) { Destroy(gameObject); } // Destroy player once 0 lives
        } else {
            Globals.SCORE += baseScore + Globals.COMBOS * Globals.COMBOS;
            Destroy(gameObject);
        }
    }
}
