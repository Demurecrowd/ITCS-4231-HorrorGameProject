using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class DoorLeverScript : MonoBehaviour
{
    public Animator leverAnim;
    public GameObject lever;
    public GameObject statue;
    public GameObject mainFrameGlow;
    public GameObject doorLeft;
    public GameObject doorRight;
    public GameObject doorClosed;
    public GameObject genLeverInteraction;
    public AudioSource leverSound;
    public AudioSource ElectricitySound;
    public bool inTrig, oneTime, genOn;
    

    void Start()
    {
        leverSound = GetComponent<AudioSource>();
    }

     private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered Trigger");
        if (other.tag == "Player")
        {
            if (!oneTime){
                inTrig = true;
                //Debug.Log("inTrig set to True");
            }
            if (oneTime)
            {
                inTrig = false;
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
            if(genLeverInteraction.GetComponent<LeverScript>().oneTime == true)
            {
                //show UI to press E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    leverSound.Play();
                    leverAnim.ResetTrigger("flip");
                    leverAnim.SetTrigger("flip");
                    //Debug.Log("Pressed E and Animation trigger set");
                    statue.SetActive(false);
                    doorClosed.SetActive(false);
                    doorRight.SetActive(true);
                    doorLeft.SetActive(true);
                    mainFrameGlow.SetActive(true);
                    ElectricitySound.Play();
                    inTrig = false;
                    oneTime = true;  
                    //Make lights function
                }
            }
        }
    }

}