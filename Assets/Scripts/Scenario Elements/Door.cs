using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string sceneToGo;
    public bool active;
    
    public float transitionTime;
    private IEnumerator DoorTransition()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Door 1");
        yield return new WaitForSeconds(transitionTime);
        Debug.Log("Fade or what ever");
        SceneManager.LoadScene(sceneToGo);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (active)
        {
            StartCoroutine(DoorTransition());
        }
    }
}
