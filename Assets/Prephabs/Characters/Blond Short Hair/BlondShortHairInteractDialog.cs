using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlondShortHairInteractDialog : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Main character" && GameObject.Find("Game State").GetComponent<CoreGameState>().blondShortHairSpeech)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            GetComponent<ShowDialogController>().StartDialog(1);
        }
    }
}
