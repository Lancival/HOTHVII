using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Usage: Attach to an object in any scene where you need beats! Manipulate the beats
// by changing values in Globals.

public class Beats : MonoBehaviour {

    // Start is called before the first frame update
    public void Start() {
        StartCoroutine(Beat());
    }

    public IEnumerator Beat() {
    	while (true) {
    		yield return new WaitForSeconds(Globals.BEAT_TIME);
    		Globals.ON_BEAT = true;
    		yield return new WaitForSeconds(Globals.BEAT_PM);
    		Globals.ON_BEAT = false;
    	}
    }

    public void StopBeat() {
        StopCoroutine(Beat());
    }
}
