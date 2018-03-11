using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCollider : MonoBehaviour {

    private Animator playerAnimator;
	// Use this for initialization
	void Start () {
        playerAnimator = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerAnimator.GetBool("aim"))
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
            person = null;
        }
	}

    private GameObject person;
    public GameObject GetAimingPerson()
    {
        return person;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Person")
        {
            person = collision.gameObject;
        }
    }


}
