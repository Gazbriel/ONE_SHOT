using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Activate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public string soundName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Main character")
        {
            GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play(soundName);
        }
    }

    public bool isTownDoor;

    private void Activate()
    {
        if (isTownDoor)
        {
            if (!GameObject.Find("Game State").GetComponent<CoreGameState>().finalScene 
                || !GameObject.Find("Game State").GetComponent<CoreGameState>().cantEnterBar 
                || !GameObject.Find("Game State").GetComponent<CoreGameState>().barTenderSpeechRichManAcusedHim 
                || !GameObject.Find("Game State").GetComponent<CoreGameState>().blondShortHairSpeechDone)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
