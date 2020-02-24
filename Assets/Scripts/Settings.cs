using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Settings : MonoBehaviour {
    // Start is called before the first frame update

	private GameObject slider;
	private GameObject buttons;

    void Start() {
    	slider = GameObject.Find("Audio Volume Slider");
    	buttons = GameObject.Find("Buttons");
        slider.GetComponent<Slider>().value = Globals.VOLUME;
        slider.GetComponent<Slider>().onValueChanged.AddListener(delegate {setAudioVolume();});
        buttons.transform.GetChild(Globals.DIFFICULTY).gameObject.GetComponent<Button>().interactable = false;
        for (int i = 0; i < 3; i++)
        	buttons.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(setDifficulty);
    }

    private void setDifficulty() {
    	buttons.transform.GetChild(Globals.DIFFICULTY).gameObject.GetComponent<Button>().interactable = true;
    	Globals.DIFFICULTY = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
    	buttons.transform.GetChild(Globals.DIFFICULTY).gameObject.GetComponent<Button>().interactable = false;
    }

    private void setAudioVolume() {
    	Globals.VOLUME = EventSystem.current.currentSelectedGameObject.GetComponent<Slider>().value;
    }
}
