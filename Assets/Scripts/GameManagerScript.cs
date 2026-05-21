using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public List<Vector3> enemyPosList;
    public GameObject Enemy;
    public GameObject Player;
    public PlayerMovementScript playerMovementScript;
    public int score;
    public int documents;
    public float enemySpawnTimer;
    public int stealth;
    public int decayBar;
    // Start is called before the first frame update
   
    void Start()
    {
        enemySpawnTimer = 0;
        score = 0;
        documents = 0;
        stealth = 1;
        for (int i = 0; i < enemyPosList.Count; i++)
        {
            Instantiate(Enemy, enemyPosList[i], Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemySpawnTimer += Time.deltaTime;
        if (enemySpawnTimer >= 2.5)
        {
            for (int i = 0; i < enemyPosList.Count; i++)
            {
                Instantiate(Enemy, enemyPosList[i], Quaternion.identity);
            }


            
        }
        if (decayBar == 100)
        {
            Player.GetComponent<PlayerMovementScript>().decayBarMax = true;
        }
    }
}

