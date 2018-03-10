using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneController : MonoBehaviour {

    public GameObject woman;
    public GameObject player;

	// Use this for initialization
	void Start () {
        //Set false the player movement
        player.GetComponent<CharacterController>().SetCanMove(false);
        //Set true the aiming on the woman
        woman.GetComponent<Animator>().SetBool("aim", true);
        //set the camera starting position
        desirePosition = new Vector3(0, 80, -10);
        Debug.Log(Camera.main.transform.position);
        StartCoroutine(SceneManagement());
	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.transform.position != desirePosition)
        {
            MoveCameraTo((int)desirePosition.x, (int)desirePosition.y);
        }
	}

    IEnumerator SceneManagement()
    {
        yield return new WaitForSeconds(2);
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Shoot");
        yield return new WaitForSeconds(1);
        MoveCameraTo(0, 0);
        yield return new WaitForSeconds(0.5f);
        //Set true the player movement
        player.GetComponent<CharacterController>().SetCanMove(true);
        woman.GetComponent<ShowDialogController>().StartDialog(0);
        yield return new WaitForSeconds(4f);
        //Set false the aiming on the woman
        woman.GetComponent<Animator>().SetBool("aim", false);
        yield return new WaitForSeconds(0.5f);
        woman.GetComponent<NPCController>().LookAt("left");
        yield return new WaitForSeconds(4f);
        woman.GetComponent<NPCController>().Move("left", 16);
        yield return new WaitForSeconds(2f);
        woman.GetComponent<NPCController>().LookAt("right");
        yield return new WaitForSeconds(7f);
        yield return new WaitUntil(WaitForAimAndLookRight);
        woman.GetComponent<ShowDialogController>().ChangeToDialog(1);
        yield return new WaitForSeconds(woman.GetComponent<ShowDialogController>().GetDialogTime(1) + 1.5f);
        //Player
        player.GetComponent<ShowDialogController>().StartDialog(0);
        yield return new WaitForSeconds(player.GetComponent<ShowDialogController>().GetDialogTime(0) + 1);
        //woman
        woman.GetComponent<ShowDialogController>().ChangeToDialog(2);
        yield return new WaitForSeconds(woman.GetComponent<ShowDialogController>().GetDialogTime(2) + 1);
        //player
        player.GetComponent<ShowDialogController>().ChangeToDialog(1);
        yield return new WaitForSeconds(player.GetComponent<ShowDialogController>().GetDialogTime(1) + 1);
        //woman
        woman.GetComponent<ShowDialogController>().ChangeToDialog(3);
        yield return new WaitForSeconds(woman.GetComponent<ShowDialogController>().GetDialogTime(3) + 1);
        //player
        player.GetComponent<ShowDialogController>().ChangeToDialog(2);
        yield return new WaitForSeconds(player.GetComponent<ShowDialogController>().GetDialogTime(2) + 1);
        //woman
        woman.GetComponent<ShowDialogController>().ChangeToDialog(4);
        yield return new WaitForSeconds(woman.GetComponent<ShowDialogController>().GetDialogTime(4) + 1);
        //player
        player.GetComponent<ShowDialogController>().ChangeToDialog(3);
        yield return new WaitForSeconds(player.GetComponent<ShowDialogController>().GetDialogTime(3) + 1);
        //woman
        woman.GetComponent<ShowDialogController>().ChangeToDialog(5);
        yield return new WaitForSeconds(woman.GetComponent<ShowDialogController>().GetDialogTime(5) + 1);
        woman.GetComponent<WeaponGirlInteract>().CanPrepareWeapon();
        Debug.Log("Fin");
    }

    #region Listen to Aim and look
    private bool WaitForAimAndLookRight()
    {
        if (player.GetComponent<Animator>().GetBool("aim") && player.GetComponent<CharacterController>().facingRight)
        {
            return true;
        }
        return false;
    }
    #endregion

    #region Move Camera
    private Vector3 desirePosition;
    public int cameraMoveSpeed;
    private void MoveCameraTo(int xPos, int yPos)
    {
        desirePosition = new Vector3(xPos, yPos, desirePosition.z);
        // x movement
        if (Camera.main.transform.position.x < desirePosition.x)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + cameraMoveSpeed, Camera.main.transform.transform.position.y, Camera.main.transform.transform.position.z);
        }
        else if (Camera.main.transform.position.x > desirePosition.x)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.transform.position.x - cameraMoveSpeed, Camera.main.transform.transform.position.y, Camera.main.transform.transform.position.z);
        }
        // y movement
        if (Camera.main.transform.position.y < desirePosition.y)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.transform.position.x, Camera.main.transform.transform.position.y + cameraMoveSpeed, Camera.main.transform.transform.position.z);
        }
        else if(Camera.main.transform.position.y > desirePosition.y)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.transform.position.x, Camera.main.transform.transform.position.y - cameraMoveSpeed, Camera.main.transform.transform.position.z);
        }

    }
    #endregion
}
