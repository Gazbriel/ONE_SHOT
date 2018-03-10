using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointerController : MonoBehaviour {

    enum MovePointerTo {Up, Down }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MovePointer();
    }
    #region Mi método Para cambiar el puntero
    private void MovePointer()
    {
        if (Input.GetButtonDown("Up"))
        {
            //SetPosition(MovePointerTo.Up);
            ChangePointerPosition(MovePointerTo.Up);
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("UIClick");
        }
        if (Input.GetButtonDown("Down"))
        {
            //SetPosition(MovePointerTo.Down);
            ChangePointerPosition(MovePointerTo.Down);
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("UIClick");
        }
    }
    //private void SetPosition(MovePointerTo moveTo)
    //{
    //    switch ((int)transform.position.y)
    //    {
    //        case 6:
    //            if (moveTo == MovePointerTo.Up)
    //            {
    //                transform.position = new Vector2(transform.position.x, -14);
    //            }
    //            else if(moveTo == MovePointerTo.Down)
    //            {
    //                transform.position = new Vector2(transform.position.x, -4);
    //            }
    //            break;
    //        case -4:
    //            if (moveTo == MovePointerTo.Up)
    //            {
    //                transform.position = new Vector2(transform.position.x, 6);
    //            }
    //            else if(moveTo == MovePointerTo.Down)
    //            {
    //                transform.position = new Vector2(transform.position.x, -14);
    //            }
    //            break;
    //        case -14:
    //            if (moveTo == MovePointerTo.Up)
    //            {
    //                transform.position = new Vector2(transform.position.x, -4);
    //            }
    //            else if (moveTo == MovePointerTo.Down)
    //            {
    //                transform.position = new Vector2(transform.position.x, 6);
    //            }
    //            break;
    //    }
    //}
    #endregion

    #region El métodod de ardillita
    public int[] labelsPositionsY;
    private int indexPosition;
    private void ChangePointerPosition(MovePointerTo action)
    {
        if (action == MovePointerTo.Down)
        {
            transform.position = new Vector2(transform.position.x, labelsPositionsY[(indexPosition + 1) % labelsPositionsY.Length]);
            indexPosition = (indexPosition + 1) % labelsPositionsY.Length;
        }
        else
        {
            transform.position = new Vector2(transform.position.x, labelsPositionsY[(indexPosition + labelsPositionsY.Length - 1) % labelsPositionsY.Length]);
            indexPosition = (indexPosition + labelsPositionsY.Length - 1) % labelsPositionsY.Length;
        }
    }
    #endregion
    
}
