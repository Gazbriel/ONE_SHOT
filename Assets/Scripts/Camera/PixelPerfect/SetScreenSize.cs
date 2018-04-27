using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreenSize : MonoBehaviour {

    public int scale;
    public bool fullScreen;

    //PlayerPrefs
    //firstOpen
    // fullScreen
    // scale


	// Use this for initialization
	void Start () {
        //if 1 is not open before
        if (PlayerPrefs.GetInt("firstOpen")!= 1)
        {
            PlayerPrefs.SetInt("fullScreen", 1);
            PlayerPrefs.SetInt("scale", 10);
            PlayerPrefs.SetInt("firstOpen", 1);
        }
        if (PlayerPrefs.GetInt("fullScreen") == 1)
        {
            fullScreen = true;
        }
        else
        {
            fullScreen = false;
        }
        //FullScreenDetect();
        //Scale();
        Screen.SetResolution(128 * PlayerPrefs.GetInt("scale"), 72 * PlayerPrefs.GetInt("scale"), fullScreen);
    }
	
	// Update is called once per frame
	void Update () {
        FullScreenDetect();
        //Scale();
        //Screen.SetResolution(128 * PlayerPrefs.GetInt("scale"), 72 * PlayerPrefs.GetInt("scale"), fullScreen);
    }

    private void Scale()
    {
        if (Input.GetKeyDown("g"))
        {
            PlayerPrefs.SetInt("scale", PlayerPrefs.GetInt("scale") + 1);
            Start();
        }
        if (Input.GetKeyDown("h"))
        {
            PlayerPrefs.SetInt("scale", PlayerPrefs.GetInt("scale") - 1);
            Start();
        }
        if (Input.GetKeyDown("j"))
        {
            if (PlayerPrefs.GetInt("fullScreen") == 0)
            {
                PlayerPrefs.SetInt("fullScreen", 1);
            }
            else
            {
                PlayerPrefs.SetInt("fullScreen", 0);
            }
            FullScreenDetect();
            Start();
            //fullScreen =!fullScreen;
        }
        if (PlayerPrefs.GetInt("scale") == 0)
        {
            PlayerPrefs.SetInt("scale", 10);
            Start();
        }
        if (Input.GetKeyDown("l"))
        {
            PlayerPrefs.SetInt("scale", 10);
            Start();
        }
    }

    private void FullScreenDetect()
    {
        if (PlayerPrefs.GetInt("fullScreen") == 1)
        {
            fullScreen = true;
        }
        else
        {
            fullScreen = false;
        }
    }

    public void Refresh()
    {
        FullScreenDetect();
        Screen.SetResolution(128 * PlayerPrefs.GetInt("scale"), 72 * PlayerPrefs.GetInt("scale"), fullScreen);
    }

    
}
