using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        Globals.SCORE = 0; // Reset score when starting new game
    }

    // Update is called once per frame
    void Update() {
        gameObject.GetComponent<TextMeshProUGUI>().SetText("Score: " + Globals.SCORE.ToString());
    }
}
