using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionController : MonoBehaviour {

    public GameObject pointer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetButtonDown("Left") || Input.GetButtonDown("Right")) && pointer.transform.position.y == pointer.GetComponent<PointerController>().labelsPositionsY[0])
        {
            //Play the sound
            GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play("UIClick");
            //if is in the first label
            //do the full screen thing
            if (PlayerPrefs.GetInt("fullScreen") == 0)
            {
                PlayerPrefs.SetInt("fullScreen", 1);
            }
            else
            {
                PlayerPrefs.SetInt("fullScreen", 0);
            }

            Camera.main.GetComponent<SetScreenSize>().Refresh();
            
        }

        //left and right on resolution
        if (Input.GetButtonDown("Left") && pointer.transform.position.y == pointer.GetComponent<PointerController>().labelsPositionsY[1])
        {
            GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play("UIClick");
            if (PlayerPrefs.GetInt("scale") > 2)
            {
                PlayerPrefs.SetInt("scale", PlayerPrefs.GetInt("scale") - 2);
            }
            Camera.main.GetComponent<SetScreenSize>().Refresh();
        }
        if (Input.GetButtonDown("Right") && pointer.transform.position.y == pointer.GetComponent<PointerController>().labelsPositionsY[1])
        {
            GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play("UIClick");
            if (PlayerPrefs.GetInt("scale") < 10)
            {
                PlayerPrefs.SetInt("scale", PlayerPrefs.GetInt("scale") + 2);
            }
            Camera.main.GetComponent<SetScreenSize>().Refresh();
        }

        //the back option
        if (Input.GetButtonDown("Interact") && pointer.transform.position.y == pointer.GetComponent<PointerController>().labelsPositionsY[2])
        {
            //return to Main Scene
            pointer.GetComponent<PointerController>().enabled = false;
            StartCoroutine(ChangeLevel(sceneToChageName));
        }
    }

    public string sceneToChageName;
    public float timeToWaitToChageLevel;
    IEnumerator ChangeLevel(string sceneName)
    {
        //yield return new WaitForSeconds(timeToWaitToChageLevel);
        float fadeTime = GameObject.Find("Fader").GetComponent<FaderScene>().BeginFade(1);
        Debug.Log("Found it");
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneName);
    }


}
