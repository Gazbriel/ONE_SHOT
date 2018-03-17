using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirHouseManDialogInteract : MonoBehaviour {

    public GameObject player;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Contact Collider")
        {
            player.GetComponent<ShowDialogController>().StartDialog(0);
        }
    }
}
