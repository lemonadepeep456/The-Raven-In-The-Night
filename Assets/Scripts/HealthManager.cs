using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    public bool hitPlayer;
    AudioManager audioManager;

    public SpriteRenderer playerSr;
    public PlayerMovementScript playerMovementScript;
    // Start is called before the first frame update
    public void ChangeHealth(int amount)
    {
       // health = maxHealth;
       health += amount;

    }
    void Start()
    {
        maxHealth = 3;

    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health >= 0)
        {
            playerSr.enabled = false;
            playerMovementScript.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hitPlayer = true;
        }
            if (hitPlayer == true)
            {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            audioManager.PlaySFX(audioManager.hurt);
            health -= 1;
                    hitPlayer = false;
            Debug.Log("Player hit once!");
            }
           

        
        if (health == 0)
        {
            playerSr.enabled = false;
            playerMovementScript.enabled = false;
        }
    }
}
