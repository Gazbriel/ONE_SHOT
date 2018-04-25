using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionDetectNumber : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ChangeNumber();
	}

    private void ChangeNumber()
    {
        int scale = PlayerPrefs.GetInt("scale");
        Debug.Log(scale);

        GetComponent<TextMesh>().text = (128*scale).ToString() + "x" + (72*scale).ToString();
    }
}
