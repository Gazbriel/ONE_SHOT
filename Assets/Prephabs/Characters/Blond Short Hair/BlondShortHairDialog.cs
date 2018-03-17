using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlondShortHairDialog : MonoBehaviour {

    public GameObject player;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Contact Collider" && !GameObject.Find("Game State").GetComponent<CoreGameState>().blondShortHairSpeech)
        {
            player.GetComponent<ShowDialogController>().StartDialog(0);
        }
    }
}
