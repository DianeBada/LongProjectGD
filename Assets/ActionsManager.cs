using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{

    public static int moneyCount = 50;
    public static bool hasDashing = false;
    public static bool hasWalking = false;
    public static bool hasJumping = false;
    public static bool hasShooting = false;
    public static bool hasClimbing = false;

    public static int actionCounter = 0;

   







    // getters and setters
    public static int MoneyCount
    {
        get { return moneyCount; }
        set { moneyCount = value; }
    }

    public static bool HasDashing
    {
        get { return hasDashing; }
        set { hasDashing = value; }
    }

    public static bool HasWalking
    {
        get { return hasWalking; }
        set { hasWalking = value; }
    }

    public static bool HasJumping
    {
        get { return hasJumping; }
        set { hasJumping = value; }
    }

    public static bool HasClimbing
    {
        get { return hasClimbing; }
        set { hasClimbing = value; }
    }

    public static bool HasShooting
    {
        get { return hasShooting; }
        set { hasShooting = value; }
    }


    public static GameManager Instance
    {
        // return reference to private instance 
        get
        {
            return Instance;
        }
    }

    private static ActionsManager instance = null;

    void Awake()
    {
        // Destroy secondary instances of GameManager
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        // Make this instance the only instance of GameManager
        instance = this;

        // Immortal Object
        DontDestroyOnLoad(gameObject);
    }

}




