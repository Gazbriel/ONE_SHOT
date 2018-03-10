using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LenguageFirstSceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Interact"))
        {
            Interact();
        }
    }

    public GameObject pointer;
    private void Interact()
    {
        Debug.Log("Interacting");
        switch ((int)pointer.transform.position.y)
        {
            case 1:
                //do
                PlayerPrefs.SetString("language", "english");
                StartCoroutine(ChangeLevel(sceneToChageName));
                break;
            case -9:
                //do
                PlayerPrefs.SetString("language", "spanish");
                StartCoroutine(ChangeLevel(sceneToChageName));
                break;
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
