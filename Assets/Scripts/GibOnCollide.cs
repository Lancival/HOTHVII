﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibOnCollide : MonoBehaviour {
    [SerializeField] private int baseScore;

    void OnTriggerEnter2D(Collider2D collider) {
        
        //Instantiate(sound, transform.position, transform.rotation);
        if (gameObject.name == "Player" && collider.gameObject.layer != 11) { // if colliding object is a player
            Globals.LIVES--;              // subtract a life
            Debug.Log("lose life");
            Debug.Log(Globals.LIVES + " lives left");
            if(Globals.LIVES == 0) { Destroy(gameObject); } // Destroy player once 0 lives
        } else if (collider.gameObject.layer == 8 && gameObject.layer == 8) {
            // If two asteroids collide, do nothing
            return;
        }
        else if (gameObject.layer == 9 && GameObject.Find("Player").GetComponent<Shoot>().PowerUpVal(1))
        {
            
        }
        else if (collider.gameObject.layer != 11) {
            Debug.Log(gameObject.layer);
            Globals.SCORE += baseScore + Globals.COMBOS * Globals.COMBOS;
            Destroy(gameObject);
        }
    }
}
