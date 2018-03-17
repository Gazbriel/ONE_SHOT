using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartenderInteractionDialog : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Main character" && GameObject.Find("Game State").GetComponent<CoreGameState>().barTenderSpeech)
        {
            //player.gameObject.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            GetComponent<ShowDialogController>().ChangeToDialog(1);
        }
    }
}
