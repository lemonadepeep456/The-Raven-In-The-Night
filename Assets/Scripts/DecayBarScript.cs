using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DecayBarScript : MonoBehaviour
{
    public int decayBar;
    public int decayBarAmount;
    public Sprite decayBarEmpty;
    public Sprite decayBar20;
    public Sprite decayBar40;
    public Sprite decayBar60;
    public Sprite decayBar80;
    public Sprite decayBarMax;
    public Image[] decay;

    public GameObject gameManagerObject;


    public GameManagerScript gameManager;
    public PlayerMovementScript playerMovementScript;


    // Start is called before the first frame update
    void Start()
    {
       // decayBar = gameManager.decayBar;
    }

    // Update is called once per frame
    void Update()
    {
        decayBarAmount = gameManager.decayBar;

        for (int i = 0; i < decay.Length; i++)
        {
            if (decayBarAmount == 0)
            {
                decay[i].sprite = decayBarEmpty;
            }
            if (decayBarAmount == 20)
            {
                decay[i].sprite = decayBar20;
            }
            if (decayBarAmount == 40)
            {
                decay[i].sprite = decayBar40;
            }
            if (decayBarAmount == 60)
            {
                decay[i].sprite = decayBar60;
            }
            if (decayBarAmount == 80)
            {
                decay[i].sprite = decayBar80;
            }
            if (decayBarAmount == 100)
            {
                decay[i].sprite = decayBarMax;
            }



           // if (i < maxHealth)
            //{
           //     hearts[i].enabled = true;
           // }
           // else
            //{
           //     hearts[i].enabled = false;
            //}
        }
    }
}
