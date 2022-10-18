using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    //Using trasform so that we can get the position of the FLOATING PLATFORMS
    public Transform position1;
    public Transform position2;
    private float speed;
    public Transform startPosition;
    Vector3 nextPosition;

    private void Start()
    {
        nextPosition = startPosition.position;
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == position1.position) //When the platform reaches is at position 1
        {
            nextPosition = position2.position; //it is moving towards position2
        }
        if (transform.position == position2.position) //When the platform reaches is at position 2
        {
            nextPosition = position1.position; //it is moving towards position1
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime); //Vector moves to next position at a certain speed

    }
}
