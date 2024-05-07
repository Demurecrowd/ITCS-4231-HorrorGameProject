using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class AddEnemyScript : MonoBehaviour
{
  
    public GameObject Enemy;
    public GameObject genLeverInteraction;
    public bool inTrig, oneTime, genOn;
    
    void Start()
    {
        Enemy.SetActive(false);
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(genOn)
            {
                if (!oneTime)
                {
                    inTrig = true;
                }
                if (oneTime)
                {
                    inTrig = false;
                }
            }    
        }
    }
    void Update()
    {
        genOn = genLeverInteraction.GetComponent<LeverScript>().genOn;
        if (inTrig)
        {
            if(genLeverInteraction.GetComponent<LeverScript>().oneTime == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Enemy.SetActive(true);

                }
            }
        }
    }

}
