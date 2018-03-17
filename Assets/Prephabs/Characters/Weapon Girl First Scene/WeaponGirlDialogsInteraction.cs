using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGirlDialogsInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Contact Collider")
        {
            GetComponent<ShowDialogController>().StartDialog(0);
            GameObject.Find("Game State").GetComponent<CoreGameState>().blondGirlSpeech = true;
        }
    }
}
