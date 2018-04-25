using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(LightOn());
        //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Title Music");
    }

    public float timeToWaitToInteract;
    private bool canInteract;

    public GameObject beging;
    public GameObject prepare;
    public GameObject quit;
    public GameObject pointer;
    public GameObject farolLight;

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Interact") && canInteract)
        {
            Interact();
        }
    }

    public string sceneBegingToChageName;
    IEnumerator ChangeLevel(string sceneName)
    {
        yield return new WaitForSeconds(1);
        //yield return new WaitForSeconds(timeToWaitToChageLevel);
        float fadeTime = GameObject.Find("Fader").GetComponent<FaderScene>().BeginFade(1);
        Debug.Log("Found it");
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneName);
    }

    private void Interact()
    {
        //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("UISelect");
        switch ((int)pointer.transform.position.y)
        {
            case 6:
                //do
                //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Stop("Title Music");
                StartCoroutine(LightOff());
                StartCoroutine(ChangeLevel(sceneBegingToChageName));
                break;
            case -4:
                //do
                StartCoroutine(LightOff());
                StartCoroutine(ChangeLevel("Prepare"));
                break;
            case -14:
                //do
                Application.Quit();
                break;
        }
    }

    #region Lights On off
    IEnumerator LightOn()
    {
        yield return new WaitForSeconds(timeToWaitToInteract);
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Light");
        beging.SetActive(true);
        prepare.SetActive(true);
        quit.SetActive(true);
        pointer.SetActive(true);
        farolLight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        beging.SetActive(false);
        prepare.SetActive(false);
        quit.SetActive(false);
        pointer.SetActive(false);
        farolLight.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Light");
        beging.SetActive(true);
        prepare.SetActive(true);
        quit.SetActive(true);
        pointer.SetActive(true);
        farolLight.SetActive(true);
        canInteract = true;
    }
    IEnumerator LightOff()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Light");
        beging.SetActive(false);
        prepare.SetActive(false);
        quit.SetActive(false);
        pointer.SetActive(false);
        farolLight.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        beging.SetActive(true);
        prepare.SetActive(true);
        quit.SetActive(true);
        pointer.SetActive(true);
        farolLight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Light");
        beging.SetActive(false);
        prepare.SetActive(false);
        quit.SetActive(false);
        pointer.SetActive(false);
        farolLight.SetActive(false);
        canInteract = true;
    }
    #endregion
}
