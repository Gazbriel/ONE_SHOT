using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGameProgress : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
        StartCoroutine(ShowProgressRoutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ShowProgressRoutine()
    {
        Debug.Log("Waiting...");
        yield return new WaitForSeconds(GameObject.Find("End Game").GetComponent<ShowDialogController>().GetDialogTime(0) -2);
        Debug.Log("Calculating...");
        GetComponent<ShowDialogController>().englishDialogs[0].sentences[0] += (GameObject.Find("Game State").GetComponent<CoreGameState>().GetProgress() + " %").ToString();
        GetComponent<ShowDialogController>().spanishDialogs[0].sentences[0] += (GameObject.Find("Game State").GetComponent<CoreGameState>().GetProgress() + " %").ToString();
        Debug.Log("Showing...");
        GetComponent<ShowDialogController>().StartDialog(0);
    }
    
}
