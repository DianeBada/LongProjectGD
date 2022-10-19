using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovementHorizontal : MonoBehaviour
{

    [SerializeField] 
    float offsetLeft = 0, offsetRight = 0, speed = 1;
    [SerializeField]
    bool hasReachedRight = false, hasReachedLeft = false;
    Vector3 startPosition = Vector3.zero;
    // Start is called before the first frame update
    void Awake()
    {
        startPosition = transform.position;
    }



// Update is called once per frame
void FixedUpdate()
    {
        if (!hasReachedRight)
        {
            if (transform.position.x < startPosition.x + offsetRight)
            {
                Move(offsetRight);

                // Move platform to the right        
            }
            else if (transform.position.x >= startPosition.x + offsetRight)
            {
                hasReachedRight = true;
                hasReachedLeft = false;
            }
        }
        else if (!hasReachedLeft)
        {
            if (transform.position.x > startPosition.x + offsetLeft)
            {
                Move(offsetLeft);

                // Move platform to the left 
            }
            else if (transform.position.x <= startPosition.x + offsetLeft)
            {
                hasReachedRight = false;
                hasReachedLeft = true;
            }
        }
    }

    void Move(float offset)
    {
        transform.position = Vector3.MoveTowards(transform.position,   new Vector3(startPosition.x + offset, transform.position.y,
         transform.position.z),speed * Time.deltaTime);
    }
}
