using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public bool resetLevel;
    public GameObject gManager;

    PurchaseActions purch;
    // Start is called before the first frame update

    void Awake()
    {
        gManager.GetComponent<PurchaseActions>();
       // purch = gameObject.GetComponent<PurchaseActions>();

    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Is Colliding with player; reset level");
            resetLevel = true;
            gManager.GetComponent<PurchaseActions>().ResetLevel();

        }
    }
}

    

    

    

