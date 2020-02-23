using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboController : MonoBehaviour {

	[SerializeField] private GameObject ComboBar;
	private int bars = 0;

	void Update() {
		if (Globals.COMBOS > bars)
			CreateBar();
		else if (Globals.COMBOS == 0)
			ClearBars();
	}

    private void CreateBar() {
        if (bars <= 50)
    	   Instantiate(ComboBar, gameObject.transform, false);
        bars++;
    }

    private void ClearBars() {
    	foreach (Transform child in gameObject.transform)
    		Destroy(child.gameObject);
    	bars = 0;
    }
}
