using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public float upSpeed;
    public float downSpeed;
    public Transform up;
    public Transform down;
    bool chop;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= up.position.y)
        {
            chop = true;
        }

        if (transform.position.y <= down.position.y)
        {
            chop = false;
        }

        if (chop)
        {
            transform.position = Vector2.MoveTowards(transform.position, down.position, downSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, up.position, upSpeed * Time.deltaTime);
        }
    }
}
