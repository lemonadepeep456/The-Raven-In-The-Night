using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyChaseScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;
    public bool isHiding;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        isHiding = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(distance < distanceBetween && isHiding == false)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            
          // transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
       // if (isHiding == true)
        

    }
}
