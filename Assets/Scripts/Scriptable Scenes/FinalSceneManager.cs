using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneManager : MonoBehaviour {

    public GameObject bandit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Aim") && Input.GetButton("Interact"))
        {
            StopAllCoroutines();
            Debug.Log("Stoping coruoutines");
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Contact Collider")
        {
            StartCoroutine(FinalRoutine());
        }
    }

    IEnumerator FinalRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        bandit.GetComponent<Animator>().SetTrigger("stopAim");
        yield return new WaitForSeconds(1f);
        bandit.GetComponent<ShowDialogController>().StartDialog(0);
        yield return new WaitForSeconds(2f);
        bandit.GetComponent<NPCController>().LookAt("left");
        yield return new WaitForSeconds(bandit.GetComponent<ShowDialogController>().GetDialogTime(0) + 2);
        bandit.GetComponent<NPCController>().Move("left", 36);
        yield return new WaitForSeconds(5f);
        bandit.GetComponent<NPCController>().LookAt("right");
        yield return new WaitForSeconds(3f);
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play("Door 1");
        yield return new WaitForSeconds(1f);
        bandit.SetActive(false);
        GameObject.Find("Main character").GetComponent<CharacterController>().EndGame();
    }

}
