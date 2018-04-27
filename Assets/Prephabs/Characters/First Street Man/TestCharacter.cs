using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //if (GameObject.Find("Game State").GetComponent<CoreGameState>().cantEnterBar)
        //{
        //    transform.position = new Vector3(-18, transform.position.y, transform.position.z);
        //}
        if (GameObject.Find("Game State").GetComponent<CoreGameState>().finalScene
            && GameObject.Find("Game State").GetComponent<CoreGameState>().blondShortHairSpeechDone
            && GameObject.Find("Game State").GetComponent<CoreGameState>().cantEnterBar
            && GameObject.Find("Game State").GetComponent<CoreGameState>().barTenderSpeechRichManAcusedHim)
        {
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
	}

    private bool aimed;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Aim Collider" && !aimed)
        {
            GetComponent<ShowDialogController>().StopAllCoroutines();
            GetComponent<ShowDialogController>().ChangeToDialog(2);
            GameObject.Find("Game State").GetComponent<CoreGameState>().blonsShortHairAndRichManConflict = true;
            aimed = true;
        }
        if (collision.gameObject.name == "Contact Collider" && GameObject.Find("Game State").GetComponent<CoreGameState>().cantEnterBar && !GetComponent<ShowDialogController>().dialoging)
        {
            GetComponent<ShowDialogController>().ChangeToDialog(2);
        }
        if (collision.gameObject.name == "Contact Collider" && !GameObject.Find("Game State").GetComponent<CoreGameState>().firstManTownInteract1 && !GetComponent<ShowDialogController>().dialoging)
        {
            GetComponent<ShowDialogController>().StartDialog(0);
        }
        if (collision.gameObject.name == "Main character" && GameObject.Find("Game State").GetComponent<CoreGameState>().firstManTownInteract1 && !GetComponent<ShowDialogController>().dialoging)
        {
            GetComponent<ShowDialogController>().ChangeToDialog(1);
        }
    }
}
