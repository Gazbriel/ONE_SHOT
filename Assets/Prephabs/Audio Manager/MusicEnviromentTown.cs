using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicEnviromentTown : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Bird 1");
        //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Bird 2");
        //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Cricket");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //if (SceneManager.GetActiveScene().name == "Town Scene")
        //{
        //    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Bird 1");
        //    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Bird 2");
        //    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Cricket");
        //}
        //else
        //{
        //    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Stop("Bird 1");
        //    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Stop("Bird 2");
        //    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Stop("Cricket");
        //}
        if (SceneManager.GetActiveScene().name == "End Game Scene")
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Stop("Cricket");
        }
	}


}
