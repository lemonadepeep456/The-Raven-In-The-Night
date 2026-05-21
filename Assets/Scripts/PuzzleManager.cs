using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PuzzleManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[] Pipes;

    public int sceneBuildIndex;

    [SerializeField]
     int totalPipes = 0;
    [SerializeField]
    int correctedPipes = 0;
    // Start is called before the first frame update
    void Start()
    {
        totalPipes = PipesHolder.transform.childCount;

        Pipes = new GameObject[totalPipes];

        for (int i = 0; i < Pipes.Length; i++)
        {

            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void CorrectMove()
    {
        correctedPipes += 1;
        Debug.Log("Correct Move!");
        if(correctedPipes == totalPipes)
        {
            Debug.Log("All pipes completed!");
        //    print("Switching Scene to " + sceneBuildIndex);
         //   SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);

        }
    }
    public void WrongMove()
    {
      correctedPipes -= 1;
     }

}