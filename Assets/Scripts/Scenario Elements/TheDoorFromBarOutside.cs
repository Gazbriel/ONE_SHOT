using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDoorFromBarOutside : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GameObject.Find("Game State").GetComponent<CoreGameState>().cantEnterBar)
        {
            gameObject.SetActive(false);
        }
	}
}
