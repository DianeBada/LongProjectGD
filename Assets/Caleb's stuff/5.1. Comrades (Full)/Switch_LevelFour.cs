using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_LevelFour : MonoBehaviour
{
    public Animator characterAnim;
    public Animator prisonAnim;
    public Animator switchAnim;
    public GameObject portalObject;
    public bool switchIsOn;

    void Start()
    {
        //Portal is NOT ACTIVE at the beginning
        portalObject.SetActive(false);

        //Switch is Off
        switchIsOn = false;
    }


    void Update()
    {
        //Press E to open prison
        if (Input.GetKeyDown(KeyCode.P))
        {
            //if the switch is On
            if (switchIsOn)
            {
                //Play aniations
                StartCoroutine(SwitchAndComrade());

                //Show portal
                portalObject.SetActive(true);
            }
        }
        
    }

    //When player Enetrs Trigger they can do THIS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Show interaction option


            //turn the switch ON
            switchIsOn = true;
        }
    }

    //Other animations
    IEnumerator SwitchAndComrade()
    {
        yield return new WaitForSeconds(2f);

        //other animations
        prisonAnim.SetBool("OpenTheCage", true);
        characterAnim.SetBool("ComradeIsFree", true);
        switchAnim.SetBool("SwitchIsPressed", true);

    }
}
