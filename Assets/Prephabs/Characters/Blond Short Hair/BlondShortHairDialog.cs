using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlondShortHairDialog : MonoBehaviour {

    public GameObject player;

    public bool aimed;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //knows about th conflict
        if (collision.gameObject.name == "Aim Collider" && GameObject.Find("Game State").GetComponent<CoreGameState>().blonsShortHairAndRichManConflict && !aimed)
        {
            player.GetComponent<ShowDialogController>().StopAllCoroutines();
            player.GetComponent<ShowDialogController>().ChangeToDialog(4);
            GameObject.Find("Game State").GetComponent<CoreGameState>().blondShorHairTalkAboutTheRichMan = true;
            aimed = true;
        }
        //dont know about th conflict
        if (collision.gameObject.name == "Aim Collider" && !aimed)
        {
            player.GetComponent<ShowDialogController>().StopAllCoroutines();
            player.GetComponent<ShowDialogController>().ChangeToDialog(3);
            aimed = true;
        }
        if (collision.gameObject.name == "Contact Collider" && !GameObject.Find("Game State").GetComponent<CoreGameState>().blondShortHairFirstWords && !GetComponentInParent<ShowDialogController>().dialoging)
        {
            player.GetComponent<ShowDialogController>().StartDialog(0);
            GameObject.Find("Game State").GetComponent<CoreGameState>().blondShortHairFirstWords = true;
        }
    }
}
