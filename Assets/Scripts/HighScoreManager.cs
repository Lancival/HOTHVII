using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour {

    void Start() {
    	for (int i = 1; i <= 10; i++) {
    		int score = GetHighScore(i);
    		if (score != -1)
    			gameObject.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(i.ToString() + ". " + score.ToString());
    	}
    }

    public static int GetHighScore(int rank) {
    	if (rank > 10 | rank < 1)
    		return -1;

    	string scoreName = "score" + rank.ToString();
    	if (PlayerPrefs.HasKey(scoreName))
    		return PlayerPrefs.GetInt(scoreName);
    	else
    		return -1;
    }

    public static int SetHighScore(int score) {
    	for (int i = 1; i <= 10; i++) {
    		int highscore = GetHighScore(i);
    		if (highscore == -1 || highscore < score) {
    			for (int j = 9; j >= i; j--)
    				if (GetHighScore(j) != -1)
    					PlayerPrefs.SetInt("score" + (j+1).ToString(), GetHighScore(j));
    			PlayerPrefs.SetInt("score" + i.ToString(), score);
    			return i;
    		}
    	}
    	return -1;
    }
}
