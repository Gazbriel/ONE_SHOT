using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    
    public int positionOnTown;

    public string sceneToGo;
    public bool active;
    
    public float transitionTime;
    public IEnumerator DoorTransition()
    {
        active = false;
        PlayerPrefs.SetInt("spawnPosition", positionOnTown);
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Door 1");
        //yield return new WaitForSeconds(transitionTime);
        //Debug.Log("Fade or what ever");
        float fadeTime = GameObject.Find("Fader").GetComponent<FaderScene>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        PlayEnviromentSounds();
        SceneManager.LoadScene(sceneToGo);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (active && collision.gameObject.name == "Main character")
        {
            GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<CharacterController>().canMove = false;
            GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<Animator>().SetBool("walking", false);
            StartCoroutine(DoorTransition());
        }
    }

    private void PlayEnviromentSounds()
    {
        //Town Scene
        if (SceneManager.GetActiveScene().name == "Town Scene")
        {
            //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Stop("Bird 1");
            //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Stop("Bird 2");
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Stop("Cricket");
        }
        if (sceneToGo == "Town Scene")
        {
            //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Bird 1");
            //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Bird 2");
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Cricket");
        }

        ////Bar Scene
        //if (SceneManager.GetActiveScene().name == "Bar")
        //{
        //    //Stop Bar
        //    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Stop("Bar Music");
        //}
        //if (sceneToGo == "Bar")
        //{
        //    //Play Bar
        //    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Bar Music");
        //}
        

    }
}
