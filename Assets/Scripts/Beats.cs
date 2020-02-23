using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beats : MonoBehaviour {
	private GameObject BEAT_TEST;

    // Start is called before the first frame update
    public void Start() {
    	BEAT_TEST = GameObject.Find("Beat Test");
        StartCoroutine(Beat());
    }

    public IEnumerator Beat() {
    	while (true) {
    		yield return new WaitForSeconds(Globals.BEAT_TIME);
    		Globals.ON_BEAT = true;
    		BEAT_TEST.SetActive(true);
    		Debug.Log("Beat!");
    		yield return new WaitForSeconds(Globals.BEAT_PM);
    		Globals.ON_BEAT = false;
    		BEAT_TEST.SetActive(false);
    		Debug.Log("No Beat!");
    	}
    }
}
