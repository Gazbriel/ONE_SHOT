using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAimingDialog : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Aim Collider" && !GameObject.Find("Game State").GetComponent<CoreGameState>().barTenderSpeechRichManAcusedHim)
        {
            Debug.Log("Thergneted");
            //stop the dialog if is dialoging and run the correspond dialog routine
            if (GetComponent<ShowDialogController>().dialoging)
            {
                StartCoroutine(StartDialogAiming());
            }
        }
    }

    public float timeToWaitToStartDialogAiming;
    IEnumerator StartDialogAiming()
    {
        GetComponent<ShowDialogController>().StopAllCoroutines();
        yield return new WaitForSeconds(timeToWaitToStartDialogAiming);
        GetComponent<ShowDialogController>().ChangeToDialog(1);
        GameObject.Find("Game State").GetComponent<CoreGameState>().barTenderSpeechRichManAcusedHim = true;
    }
}
