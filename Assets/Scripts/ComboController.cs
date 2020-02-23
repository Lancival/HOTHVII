using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboController : MonoBehaviour {

	[SerializeField] private GameObject ComboBar;
	private int bars = 0;

	void Update() {
        if (Input.GetKeyDown("space")) {
            Debug.Log(Globals.ON_BEAT);
            Globals.COMBOS++;
        }
		if (Globals.COMBOS > bars)
			CreateBar();
		else if (Globals.COMBOS == 0)
			ClearBars();
	}

    private void CreateBar() {
    	var newBar = Instantiate(ComboBar, gameObject.transform, false);
    	if (bars <= 50)
    		newBar.GetComponent<Image>().color = new Color(255, 255 - bars * 5, 255 - bars * 5, 255);
        bars++;
    }

    private void ClearBars() {
    	foreach (Transform child in gameObject.transform)
    		Destroy(child.gameObject);
    	bars = 0;
    }
}
