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
    private int missed = 0; // Number of beats since combo last increased
    private int prev_combo = 0; // Number of combos at the last beat
    private int prev_score = 0; // Score at the last beat

    // Start is called before the first frame update
    public void Start() {
        indicator = gameObject.GetComponent<AudioSource>();
        indicator.volume = Globals.VOLUME * 0.9;
        StartCoroutine(Beat());
    }

    public IEnumerator Beat() {
    	while (true) {
            for (int i = 0; i < beat_list.Count; i++)
                yield return new WaitForSeconds(Globals.BEAT_TIME * beat_list[i] / list_sum);
                Globals.ON_BEAT = true;
                beats++;
                StartCoroutine(OffBeat());

            if ((Globals.COMBOS == prev_combo && Globals.COMBOS != 0) || (prev_score == Globals.SCORE && Globals.SCORE != 0))
                missed++;
            if (missed >= 6)
                missed = Globals.COMBOS = 0;
            prev_combo = Globals.COMBOS;
            prev_score = Globals.SCORE;
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
