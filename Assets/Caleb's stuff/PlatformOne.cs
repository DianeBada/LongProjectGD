using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOne : MonoBehaviour
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
        speed = 3f;
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

    //Make the ball a child when on the platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the object that is colliding has the tag "Tag"
        if (collision.gameObject.CompareTag("Player"))
        {
            //Set the parent of that object to the platform
            collision.collider.transform.SetParent(transform);

            print("It is colliding");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //If the object that is colliding has the tag "Tag"
        if (collision.gameObject.CompareTag("Player"))
        {
            //no longer a child of the object
            collision.collider.transform.SetParent(null);

            print("no longer colliding");
        }
    }
}
