using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartenderInteractionDialog : MonoBehaviour {

    private bool noMoreTalk;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Main character" && !noMoreTalk)
        {
            //has priority the upper dialog
            if (GameObject.Find("Game State").GetComponent<CoreGameState>().barTenderSpeechRichManAcusedHim
            && !GetComponent<ShowDialogController>().dialoging)
            {
                GetComponent<ShowDialogController>().ChangeToDialog(2);
                noMoreTalk = true;
            }

            if (GameObject.Find("Game State").GetComponent<CoreGameState>().barTenderSpeech && !GetComponent<ShowDialogController>().dialoging)
            {
                //player.gameObject.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                GetComponent<ShowDialogController>().ChangeToDialog(1);
            }
        }
        
        //--------------------
        
        
    }
}
