using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class FlashLightPickupScript : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject playerlight;
    public bool inTrig;
    public bool oneTime;
    private AudioSource pickupSound;


    private void Start()
    {
        playerlight.GetComponent<Flashlight>().hasLight = false;
        pickupSound = GetComponent<AudioSource>();
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
        }
        
    }
    void Update()
    {
        if (inTrig)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //set flashlight in players hand as active and make players hand flashlight not possible to open before
                //Debug.Log("Pressed E and Animation trigger set");
                playerlight.GetComponent<Flashlight>().hasLight = true;
                inTrig = false;
                oneTime = true;
                pickupSound.Play();
                flashlight.SetActive(false);
                onCollect();
                
            }
        }
    }

    void onCollect()
    {
        //Show "Press F to activate flashlight"
        playerlight.GetComponent<Flashlight>().m_light.enabled = true;
    }

}