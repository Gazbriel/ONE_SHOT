using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenuTranslator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetString("language") == "english")
        {
            GetComponent<TextMesh>().text = englishLabel;
        }
        else
        {
            GetComponent<TextMesh>().text = spanishLabel;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string englishLabel;
    public string spanishLabel;
}
