using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LifeBarManager : MonoBehaviour
{
    [SerializeField] GameObject lifebar;
    [SerializeField] private string sceneName;
    private int numBars;
    // Start is called before the first frame update
    void Start()
    {
        numBars = 3;
        Instantiate(lifebar, gameObject.transform);
        Instantiate(lifebar, gameObject.transform);
        Instantiate(lifebar, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(Globals.LIVES == 2 && numBars == 3) {
            Destroy(gameObject.transform.GetChild(2).gameObject);
            numBars--;
        }
        if(Globals.LIVES == 1 && numBars == 2) {
            Destroy(gameObject.transform.GetChild(1).gameObject);
            numBars--;
        }
        if(Globals.LIVES == 0 && numBars == 1) {
            Destroy(gameObject.transform.GetChild(0).gameObject);
            numBars--;
            SceneManager.LoadScene(sceneName);
        }
    }
}
