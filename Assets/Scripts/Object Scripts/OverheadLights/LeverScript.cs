using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public Animator leverAnim;
    public GameObject lever;
    public bool inTrig;
    public bool oneTime;
    public bool genOn;
    public AudioSource pullSound;
    public AudioSource generatorSound;

    


     private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered Trigger");
        if (other.tag == "Player")
        {
            if (!oneTime){
                inTrig = true;
                //Debug.Log("inTrig set to True");
            }
            // else
            // {
            //     Debug.Log("oneTime is true");
            // }
        }
        
    }
    void Update()
    {
        if (inTrig)
        {
            //show UI to press E
            if (Input.GetKeyDown(KeyCode.E))
            {
                leverAnim.ResetTrigger("flip");
                leverAnim.SetTrigger("flip");
                //Debug.Log("Pressed E and Animation trigger set");
                pullSound.Play();
                generatorSound.PlayDelayed(1);
                genOn = true;
                inTrig = false;
                oneTime = true;  
            }
        }
    }

}
