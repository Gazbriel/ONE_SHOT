using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirHouseManDialogInteract : MonoBehaviour {

    public GameObject player;

    public bool aimed;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Aim Collider" && GameObject.Find("Game State").GetComponent<CoreGameState>().blondShorHairTalkAboutTheRichMan && !aimed)
        {
            //aim animation
            GetComponentInParent<Animator>().SetBool("aim", true);
            StartCoroutine(CheckAimPlayer());
            GameObject.Find("Game State").GetComponent<CoreGameState>().finalScene = true;
            //dialog when aiming and knowing the things
            GetComponentInParent<ShowDialogController>().StopAllCoroutines();
            player.GetComponent<ShowDialogController>().ChangeToDialog(2);
            aimed = true;
        }
        if (collision.gameObject.name == "Aim Collider" && !aimed)
        {
            //dialog when aiming and not knowing anything
            GetComponentInParent<ShowDialogController>().StopAllCoroutines();
            player.GetComponent<ShowDialogController>().ChangeToDialog(1);
            aimed = true;
        }
        if (collision.gameObject.name == "Contact Collider" && !GameObject.Find("Game State").GetComponent<CoreGameState>().firstDialogMafiosoDone && !GetComponentInParent<ShowDialogController>().dialoging)
        {
            player.GetComponent<ShowDialogController>().StartDialog(0);
            GameObject.Find("Game State").GetComponent<CoreGameState>().firstDialogMafiosoDone = true;
        }
        if (collision.gameObject.name == "Main character" && GameObject.Find("Game State").GetComponent<CoreGameState>().blondShorHairTalkAboutTheRichMan && !aimed && !GetComponentInParent<ShowDialogController>().dialoging)
        {
            //dialog interact when knowing
            player.GetComponent<ShowDialogController>().ChangeToDialog(3);
        }
    }

    IEnumerator CheckAimPlayer()
    {
        yield return new WaitForSeconds(player.GetComponent<ShowDialogController>().GetDialogTime(2) + 4);
        if (GameObject.Find("Main character").GetComponent<Animator>().GetBool("aim"))
        {
            Debug.Log("Shooooooot");
            GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play("Shoot");
            GameObject.Find("Main character").GetComponent<CharacterController>().EndGame();
            GameObject.Find("Main character").GetComponent<Animator>().SetTrigger("die");


        }
    }
}
