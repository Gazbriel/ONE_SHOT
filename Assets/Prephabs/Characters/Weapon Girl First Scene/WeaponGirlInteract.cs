using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGirlInteract : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private bool prepareWeapon;
    public void CanPrepareWeapon()
    {
        Debug.Log("prepare es true");
        prepareWeapon = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (prepareWeapon)
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Charge Weapon");
            GameObject.Find("Weapon Girl").GetComponent<ShowDialogController>().ChangeToDialog(6);
            Debug.Log("Prepare Weapon");
            prepareWeapon = false;
        }
    }
    
}
