using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDialogueScript : MonoBehaviour
{

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;
    public float wordSpeed;
    public bool playerIsClose;
    public PlayerMovementScript playerMovementScript;


    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerIsClose)
        {
            if (dialogueText.text == dialogue[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogue[index];

            }
            if (playerIsClose == true && playerMovementScript.playerFacing == -1)
            {
            
            }
        }
 }

    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        playerMovementScript.canMove = true;
        
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        Debug.Log(index);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            RemoveText();
            dialoguePanel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialoguePanel.SetActive(true);
            playerIsClose = true;
            playerMovementScript.canMove = false;
            StartCoroutine(Typing());
            
            

        }
        

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            playerMovementScript.canMove = true;
            RemoveText();
            dialoguePanel.SetActive(false);

        }
    }
}