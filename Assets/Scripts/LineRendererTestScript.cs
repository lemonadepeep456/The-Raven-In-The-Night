using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTestScript : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private LineControllerScript line;
    // Start is called before the first frame update
   private void Start()
    {
        line.SetUpLine(points);
    }


}
