using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTownScene : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        //the conditions are the final and that you have talk with the las man on map and cant enter the bar.
        if (GameObject.Find("Game State").GetComponent<CoreGameState>().finalScene && GameObject.Find("Game State").GetComponent<CoreGameState>().barTenderSpeechRichManAcusedHim && GameObject.Find("Game State").GetComponent<CoreGameState>().cantEnterBar)
        {
            var doors = GameObject.FindGameObjectsWithTag("Door");
            foreach (var door in doors)
            {
                if (door.name == "House 3 Door")
                {
                    finalDoor = door;
                }
                door.SetActive(false);
            }
            StartCoroutine(ActiveFinalScene());
        }
	}
    private GameObject finalDoor;
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ActiveFinalScene()
    {
        yield return new WaitForSeconds(10);
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play("Shoot");
        finalDoor.SetActive(true);
        finalDoor.GetComponent<Door>().sceneToGo = "Final Scene";
    }
}
