using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpulsePlayerFromBar : MonoBehaviour {

    public GameObject player;
    public GameObject barTender;
    public GameObject boy;
    public GameObject girl;

    public GameObject barDoor;

    // Use this for initialization
    void Start () {
		
	}

    private bool done;
	// Update is called once per frame
	void FixedUpdate () {
        if (player.GetComponent<Animator>().GetBool("aim") && !done)
        {
            //do the thing
            //shut up any of the thre is talking
            StartCoroutine(GetOutRoutine());
            done = true;
        }
	}

    IEnumerator GetOutRoutine()
    {
        GameObject.Find("Game State").GetComponent<CoreGameState>().cantEnterBar = true;
        yield return new WaitForSeconds(0.2f);
        barTender.GetComponent<ShowDialogController>().StopAllCoroutines();
        barTender.GetComponent<ShowDialogController>().dialogTextVisual.GetComponent<Text>().text = "";
        boy.GetComponent<ShowDialogController>().StopAllCoroutines();
        boy.GetComponent<ShowDialogController>().dialogTextVisual.GetComponent<Text>().text = "";
        girl.GetComponent<ShowDialogController>().StopAllCoroutines();
        girl.GetComponent<ShowDialogController>().dialogTextVisual.GetComponent<Text>().text = "";
        barTender.GetComponent<Animator>().SetBool("target", true);
        barTender.gameObject.transform.localScale = new Vector3(-barTender.gameObject.transform.localScale.x, barTender.gameObject.transform.localScale.y, barTender.gameObject.transform.localScale.z);
        barTender.GetComponent<ShowDialogController>().ChangeToDialog(3);
        yield return new WaitForSeconds(barTender.GetComponent<ShowDialogController>().GetDialogTime(3) + 2);
        //expulse it from the bar
        StartCoroutine(barDoor.GetComponent<Door>().DoorTransition());
        
        //make true a variable to never enter again the bar
        //do it from before.
    }
}
