using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<ShowDialogController>().englishDialogs[0].sentences[0] += (GameObject.Find("Game State").GetComponent<CoreGameState>().GetProgress() + " %").ToString();
        GetComponent<ShowDialogController>().spanishDialogs[0].sentences[0] += (GameObject.Find("Game State").GetComponent<CoreGameState>().GetProgress() + " %").ToString();

        GetComponent<ShowDialogController>().StartDialog(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
