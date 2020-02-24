using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInvis : MonoBehaviour
{
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
