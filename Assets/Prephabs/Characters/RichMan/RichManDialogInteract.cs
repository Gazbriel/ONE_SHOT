using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichManDialogInteract : MonoBehaviour {

    public GameObject player;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Contact Collider")
        {
            player.gameObject.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            player.GetComponent<ShowDialogController>().StartDialog(0);
        }
    }
}
