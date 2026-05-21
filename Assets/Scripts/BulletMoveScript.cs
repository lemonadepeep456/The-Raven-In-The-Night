using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveScript : MonoBehaviour
{
    public Vector3 bulletMove;
    public float bulletTimer;

    public GameObject gameManagerObject;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position += bulletMove;
        bulletTimer += Time.deltaTime;

        if (bulletTimer > 0.2f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            gameManagerObject.GetComponent<GameManagerScript>().score += 10;
            gameManagerObject.GetComponent<GameManagerScript>().decayBar += 20;
        }


    }
}

