using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {
    public bool facingRight;
	// Use this for initialization
	void Start () {
        speedCounter = speed;
        facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
        TimeCounterToMove();
	}


    private bool startMove;
    public float speed;
    private float speedCounter;
    private int stepCounter; //take the vaue of distance and start decreassing
    public void Move(string direction, int distance)
    {
        if (direction == "right")
        {
            LookAt("right");
        }
        else
        {
            LookAt("left");
        }
        stepCounter = distance;
        startMove = true;
        GetComponent<Animator>().SetBool("walking", true);
    }
    private void MoveThePlayer(int distance)
    {
        if (startMove)
        {
            if (stepCounter > 0)
            {
                if (facingRight)
                {
                    transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                }
                stepCounter--;
            }
            else
            {
                GetComponent<Animator>().SetBool("walking", false);
                startMove = false;
            }
        }
    }
    private void TimeCounterToMove()
    {
        if (speedCounter < 0)
        {
            MoveThePlayer(stepCounter);
            speedCounter = speed;
        }
        else
        {
            speedCounter -= Time.deltaTime;
        }
    }

    public void LookAt(string direction)
    {
        if (direction == "left")
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
    }
}
