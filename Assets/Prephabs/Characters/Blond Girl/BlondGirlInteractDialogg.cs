using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlondGirlInteractDialogg : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Main character" && GameObject.Find("Game State").GetComponent<CoreGameState>().blondGirlSpeech && !GetComponent<ShowDialogController>().dialoging)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            GetComponent<ShowDialogController>().ChangeToDialog(1);
            GameObject.Find("Game State").GetComponent<CoreGameState>().blondShortHairSpeech = true;
        }
    }
}
