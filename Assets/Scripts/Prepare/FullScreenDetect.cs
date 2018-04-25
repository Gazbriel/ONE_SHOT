using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenDetect : MonoBehaviour {

    public Sprite isTrue;
    public Sprite isFalse;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void FixedUpdate () {
        if (PlayerPrefs.GetInt("fullScreen") == 0)
        {
            GetComponent<SpriteRenderer>().sprite = isFalse;
        }
        if (PlayerPrefs.GetInt("fullScreen") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = isTrue;
        }
    }
}
