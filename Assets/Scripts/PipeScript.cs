using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotation;
    [SerializeField]
    bool isPlaced;

    int PossibleRots = 1;

    PuzzleManager puzzleManager;

    public void Awake()
    {
        puzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
    }
    private void Start()
    {
        PossibleRots = correctRotation.Length;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if(PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || (transform.eulerAngles.z == correctRotation[1] && isPlaced == false))
            {
                isPlaced = true;
                puzzleManager.CorrectMove();
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else
        {
            if (Mathf.Abs(transform.eulerAngles.z - correctRotation[0]) <= 1 && isPlaced == false)
            {
                isPlaced = true;
                puzzleManager.CorrectMove();
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if (PossibleRots > 1)
        {
                if (transform.eulerAngles.z == correctRotation[0] || (transform.eulerAngles.z == correctRotation[1] && isPlaced == false))
                {

                    isPlaced = true;
                    puzzleManager.CorrectMove();
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
                else if (isPlaced == true)
                {
                    isPlaced = false;
                    puzzleManager.WrongMove();

                }
        }
        else
        {
            if (Mathf.Abs(transform.eulerAngles.z - correctRotation[0]) <= 1 && isPlaced == false)
            {

                    isPlaced = true;
                    puzzleManager.CorrectMove();
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;

                }
                else if (isPlaced == true)
                {

                    isPlaced = false;
                    puzzleManager.WrongMove();

                }
            }
        }
    }

