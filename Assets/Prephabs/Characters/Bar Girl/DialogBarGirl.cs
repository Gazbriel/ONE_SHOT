using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBarGirl : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Main character")
        {
            //player.gameObject.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            GetComponent<ShowDialogController>().StartDialog(0);
            GameObject.Find("Game State").GetComponent<CoreGameState>().firstManTownInteract1 = true;
        }
    }
}
