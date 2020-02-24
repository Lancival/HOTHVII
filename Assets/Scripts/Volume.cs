using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour {

	[SerializeField] private float scaleFactor = 1.0f;
	[SerializeField] private bool playNow = false;
    // Start is called before the first frame update
    void Start() {
        gameObject.GetComponent<AudioSource>().volume = Globals.VOLUME * scaleFactor;
        if (playNow)
        	gameObject.GetComponent<AudioSource>().Play(0);
    }
}
