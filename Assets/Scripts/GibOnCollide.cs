using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibOnCollide : MonoBehaviour
{
    public int value; 

    void OnTriggerEnter()
    {
        //Instantiate(sound, transform.position, transform.rotation);
        //ManageGame.score+= value;
        Destroy(gameObject);
    }
}
