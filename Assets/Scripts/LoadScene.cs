using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

	[SerializeField] private string name;

    // Start is called before the first frame update
    void Start() {
        gameObject.GetComponent<Button>().onClick.AddListener(Load);
    }

    private void Load() {
				if(name == "Gameplay") {
					Globals.SCORE = 0;
					Globals.LIVES = 3;
					Globals.COMBOS = 0;
				}
    		SceneManager.LoadScene(name);
    }
}
