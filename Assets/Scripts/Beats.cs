using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Usage: Attach to the Main Camera, which should have an audio source on it. Manipulate the beats
// by changing values in Globals.

public class Beats : MonoBehaviour {

    private List<int> beat_list = new List<int>(new int[] {1});
    private int list_sum = 1;
    private int beats = 0; // Number of beats started, only off_beat when equal to 0
    private AudioSource indicator;

    // Start is called before the first frame update
    public void Start() {
        indicator = gameObject.GetComponent<AudioSource>();
        StartCoroutine(Beat());
    }

    public IEnumerator Beat() {
    	while (true) {
            for (int i = 0; i < beat_list.Count; i++)
    		  yield return new WaitForSeconds(Globals.BEAT_TIME * beat_list[i] / list_sum);
    		  Globals.ON_BEAT = true;
              beats++;
    		  StartCoroutine(OffBeat());
    	}
    }

    public IEnumerator OffBeat() {
        yield return new WaitForSeconds(Globals.BEAT_LEN / 2);
        indicator.Play(0);
        yield return new WaitForSeconds(Globals.BEAT_LEN / 2);
        beats--;
        if (beats == 0)
            Globals.ON_BEAT = false;
    }

    public void StopBeat() {
        StopCoroutine(Beat());
    }
}
