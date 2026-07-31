using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{


    public Vector3 leftDirection;
    public Vector3 rightDirection;
    public Vector3 upDirection;
    public Vector3 downDirection;
    public Vector3 crateOffSet;
    public Vector3 cratePosition;
    public Vector3 leftBulletOffset;
    public Vector3 rightBulletOffset;
    public Vector3 upBulletOffset;
    public Vector3 downBulletOffset;
    public Vector3 playerFacingRightOffset;
    public Vector3 playerFacingLeftOffset;
    public Vector3 playerFacingDownOffset;
    public Vector3 playerFacingUpOffset;
    public GameObject Crate;
    public GameObject Player;
    public GameObject dialogueBox;
    public GameObject gameManagerObject;
    public GameObject decaySlashRight;
    public GameObject decaySlashLeft;
    public GameObject decaySlashFront;
    public GameObject decaySlashBack;
    public GameObject Enemy;
    public PlayerMovementScript playerMovementScript;
    public EnemyChaseScript enemyChaseScript;
    public GameManagerScript gameManagerScript;
    public InventoryManager inventoryManager;
    public bool inventoryMenu;
    public Sprite crate;
    public int playerFacing;
    public int decayBar;
    public bool isHiding;
    public bool isByCrate;
    public bool canMove;
    public bool enemyCanDetect;
    public bool normalForm;
    public bool decayForm;
    public bool decayBarMax;
    public float timer;

    AudioManager audioManager;
    Animator animator;
    // Start is called before the first frame update

    // private void Awake()
    //{
    //    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    //  }
    void Start()
    {
        canMove = true;
        normalForm = true;
        decayForm = false;
        decayBar = 0; 
        decayBarMax = false;
       


    }


    // Update is called once per frame
    void Update()
    {
        if (canMove == true && normalForm == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Transform>().position += leftDirection * Time.deltaTime;
                GetComponent<Animator>().Play("Dakota(SideWalkRemake)");
                GetComponent<SpriteRenderer>().flipX = false;
                playerFacing = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Transform>().position += rightDirection * Time.deltaTime;
                GetComponent<Animator>().Play("Dakota(SideWalkRemake)");
                GetComponent<SpriteRenderer>().flipX = true;
                playerFacing = 1;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Transform>().position += upDirection * Time.deltaTime;
                GetComponent<Animator>().Play("Dakota(BackWalkRemake)");
                playerFacing = 2;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Transform>().position += downDirection * Time.deltaTime;
                GetComponent<Animator>().Play("Dakota(FrontWalkRemake)");
                playerFacing = -2;
            }
            else if (playerFacing == -2)
            {
                GetComponent<Animator>().Play("Dakota(FrontIdleRemake)");
            }
             else if (playerFacing == -1)
            {
                GetComponent<Animator>().Play("Dakota(SideIdleRemake)");
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (playerFacing == 1)
            {
                GetComponent<Animator>().Play("Dakota(SideIdleRemake)");
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (playerFacing == 2)
            {
                GetComponent<Animator>().Play("Dakota(BackIdleRemake)");
             
            }
            if (Input.GetKey(KeyCode.Z) && normalForm == true && decayBarMax == true)
            {
                decayForm = true;
                normalForm = false;
            }
        }
        if (canMove == true && decayForm == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Transform>().position += leftDirection * Time.deltaTime;
                GetComponent<Animator>().Play("DecayWalk(Left)");
                GetComponent<SpriteRenderer>().flipX = true;
                playerFacing = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Transform>().position += rightDirection * Time.deltaTime;
                GetComponent<Animator>().Play("DecayWalk(Right)");
                GetComponent<SpriteRenderer>().flipX = false;
                playerFacing = 1;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Transform>().position += upDirection * Time.deltaTime;
                GetComponent<Animator>().Play("Decay(BackWalk)");
                playerFacing = 2;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Transform>().position += downDirection * Time.deltaTime;
                GetComponent<Animator>().Play("Decay(FrontWalk)");
                playerFacing = -2;
            }
            else if (playerFacing == 2)
            {
                GetComponent<Animator>().Play("Decay(IdleBack)");
            }
            else
            {
                GetComponent<Animator>().Play("Decay(Idle)");
            }

            if (Input.GetKey(KeyCode.Q) && decayForm == true)
            {
                decayForm = false;
                normalForm = true;
            }
            if (Input.GetMouseButtonDown(0) && decayForm == true)
            {
                if (playerFacing == 1)
                {
                    Instantiate(decaySlashRight, GetComponent<Transform>().position + rightBulletOffset,
                        Quaternion.identity);
                    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
                    audioManager.PlaySFX(audioManager.slash);
                }
                if (playerFacing == -1)
                {
                    Instantiate(decaySlashLeft, GetComponent<Transform>().position + leftBulletOffset,
                        Quaternion.identity);
                    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
                    audioManager.PlaySFX(audioManager.slash);
                }
                if (playerFacing == 2)
                {
                    Instantiate(decaySlashFront, GetComponent<Transform>().position + upBulletOffset,
                        Quaternion.identity);
                    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
                    audioManager.PlaySFX(audioManager.slash);
                }
                if (playerFacing == -2)
                {
                    Instantiate(decaySlashBack, GetComponent<Transform>().position + downBulletOffset,
                        Quaternion.identity);
                    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
                    audioManager.PlaySFX(audioManager.slash);
                }
            }
        }
        if (Vector3.Distance(transform.position, Crate.transform.position) < 5)
        {
            isByCrate = true;
            Debug.Log("Crate is interactable! Go closer");
        }
        if (Input.GetKeyDown(KeyCode.E) && (isHiding == false) && isByCrate == true)
        {
            isHiding = true;
            Enemy.GetComponent<EnemyChaseScript>().isHiding = true;
            canMove = false;
            Player.transform.position = Crate.transform.position + crateOffSet;
            Crate.GetComponent<SpriteRenderer>().sprite = null;
            Debug.Log("You are now hiding!");
            GetComponent<Animator>().Play("Hide");
            enemyCanDetect = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && (isHiding == true))
        {
            isHiding = false;
            canMove = true;
            Debug.Log("You are now out of hiding!");
            Crate.GetComponent<SpriteRenderer>().sprite = crate;
            enemyCanDetect = true;
            decayBar += 20;
            Enemy.GetComponent<EnemyChaseScript>().isHiding = false;
            gameManagerObject.GetComponent<GameManagerScript>().decayBar += 20;
        }
      
    }
        void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.tag == "Document")
            {
                gameManagerObject.GetComponent<GameManagerScript>().score += 1;
                gameManagerObject.GetComponent<GameManagerScript>().documents += 1;
                Destroy(collision.gameObject);
            }

        }

    }

















