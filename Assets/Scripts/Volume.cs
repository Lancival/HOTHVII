﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        gameObject.GetComponent<AudioSource>().volume = Globals.VOLUME;
    }
}