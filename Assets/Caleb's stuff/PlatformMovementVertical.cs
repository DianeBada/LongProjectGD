using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementVertical : MonoBehaviour
{


    [SerializeField]
    float offsetTop = 0, offsetBottom = 0, speed = 1;
    [SerializeField]
    bool hasReachedTop = false, hasReachedBottom = false;
    Vector3 startPosition = Vector3.zero;
    // Start is called before the first frame update
    void Awake()
    {
        startPosition = transform.position;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hasReachedTop)
        {
            if (transform.position.y < startPosition.y + offsetBottom)
            {
                Move(offsetBottom);

                // Move platform to the right        
            }
            else if (transform.position.y >= startPosition.y + offsetBottom)
            {
                hasReachedTop = true;
                hasReachedBottom = false;
            }
        }
        else if (!hasReachedBottom)
        {
            if (transform.position.y > startPosition.y + offsetTop)
            {
                Move(offsetTop);

                // Move platform to the left 
            }
            else if (transform.position.y <= startPosition.y + offsetTop)
            {
                hasReachedTop = false;
                hasReachedBottom = true;
            }
        }
    }

    void Move(float offset)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + offset,
         transform.position.z), speed * Time.deltaTime);
    }
}
