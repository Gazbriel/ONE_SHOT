using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour {

    public float speed;
    private float speedCounter;
    public bool canShoot;//this is only for the end game.
    public bool canMove;
    public bool startFacingRight;
    public void SetCanMove(bool a)
    {
        canMove = a;
    }
    public bool onTownScene;
    private void Start()
    {
        if (onTownScene)
        {
            LoadPositionOnScene();
        }
        
        if (startFacingRight)
        {
            Flip("right");
        }
        else
        {
            Debug.Log("Fliping left");
            Flip("left");
        }
        speedCounter = speed;
    }
    
    void FixedUpdate()
    {
        if (canMove)
        {
            if (!Input.GetButton("Aim")) //if the player is not aiming, then move
            {
                TimeCounterToMove();
            }
            Aim();
        }
    }

    private void Update()
    {
        if (canShoot)
        {
            Shoot();
        }
        
        Interact();
    }

    #region Move
    private void TimeCounterToMove()
    {
        if (speedCounter < 0)
        {
            Move();
            speedCounter = speed;
        }
        else
        {
            speedCounter -= Time.deltaTime;
        }
    }
    
    private void Move()
    {
        //Debug.Log("moving");
        if (Input.GetButton("Right") && transform.position.x < rightWalkeableAmount)
        {
            Flip("right");
            GetComponent<Animator>().SetBool("walking", true);
            gameObject.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
        }
        else if (Input.GetButton("Left") && transform.position.x > leftWalkeableAmount)
        {
            Flip("left");
            GetComponent<Animator>().SetBool("walking", true);
            gameObject.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
        }
        else
        {
            GetComponent<Animator>().SetBool("walking", false);
        }
        
    }
    #endregion
    #region Shoot && Almost shoot

    public bool almostShoot;
    private void Shoot()
    {
        if (almostShoot && Input.GetButton("Interact") && GetComponent<Animator>().GetBool("aim"))
        {
            GetComponent<Animator>().SetBool("shoot", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("shoot", false);
        }

        if (!almostShoot && Input.GetButtonDown("Interact") && GetComponent<Animator>().GetBool("aim"))
        {
            if (GetComponentInChildren<AimCollider>().GetAimingPerson() != null)
            {
                Debug.Log("Shoot to " + GetComponentInChildren<AimCollider>().GetAimingPerson().name + ", end game");
                if (facingRight)
                {
                    GetComponentInChildren<AimCollider>().GetAimingPerson().GetComponent<NPCController>().LookAt("left");
                }
                else
                {
                    GetComponentInChildren<AimCollider>().GetAimingPerson().GetComponent<NPCController>().LookAt("right");
                }
                //Remove Dialogs.
                GameObject.Find("Dialogs").SetActive(false);
                //----------------
                GetComponentInChildren<AimCollider>().GetAimingPerson().GetComponent<Animator>().SetTrigger("die");
            }
            else
            {
                Debug.Log("Shoot, end game");
            }
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Shoot");
            EndGame();
        }
        
    }
    #endregion
    #region Interact Collider
    public float timeToDisableCollider;
    private void Interact()
    {
        if (Input.GetButtonDown("Interact") && !GetComponent<Animator>().GetBool("aim"))
        {
            //interact
            //Debug.Log("Interacting");
            GetComponent<BoxCollider2D>().enabled = true;
            StartCoroutine(DisableCollider2D());
        }
    }
    IEnumerator DisableCollider2D()
    {
        yield return new WaitForSeconds(timeToDisableCollider);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public int rightWalkeableAmount;
    public int leftWalkeableAmount;//the x is the position, the y is the length;
    #endregion

    #region Fliping
    public bool facingRight = true;
    private void Flip(string direction)
    {
        if (direction == "right" && !facingRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            facingRight = true;
        }
        if (direction == "left" && facingRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            facingRight = false;
        }
    }
    #endregion

    #region Animating Aim
    private void Aim()
    {
        if (Input.GetButton("Aim"))
        {
            GetComponent<Animator>().SetBool("aim", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("aim", false);
        }
    }

    #endregion

    #region End Game
    public void EndGame()
    {

        gameObject.GetComponent<CharacterController>().canShoot = false;
        gameObject.GetComponent<CharacterController>().canMove = false;
        //gameObject.GetComponent<CharacterController>().almostShoot = true;

        StartCoroutine(EndGameRoutine());
    }


    private IEnumerator EndGameRoutine()
    {
        GameObject fader = GameObject.Find("Fader");
        yield return new WaitForSeconds(5);
        float fadeTime = fader.GetComponent<FaderScene>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("End Game Scene");
    }
    #endregion

    #region Town Position Controller
    private void LoadPositionOnScene()
    {
        transform.position = new Vector3(PlayerPrefs.GetInt("spawnPosition"), transform.position.y, transform.position.z);
    }
    #endregion
}

