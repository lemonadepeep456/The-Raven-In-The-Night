using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    [TextArea]
    [SerializeField]
    private string itemDescription;
    AudioManager audioManager;
    private InventoryManager InventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        InventoryManager = GameObject.Find("Inventory Canvas").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          int leftOverItems = InventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            if (leftOverItems <= 0)
            {
                audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
                audioManager.PlaySFX(audioManager.foodCollection);
                Destroy(gameObject);
            }
            else
                quantity = leftOverItems;
            
        }
    }
}
