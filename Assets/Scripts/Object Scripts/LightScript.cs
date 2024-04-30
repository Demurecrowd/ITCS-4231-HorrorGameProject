using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private GameObject lightSwitch;
    public GameObject lights;
    public GameObject light2;
    private bool lightOn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        lightSwitch = GameObject.FindGameObjectWithTag("lightSwitch");
    }

    // Update is called once per frame
    void Update()
    {
        lightOn = lightSwitch.GetComponent<LeverScript>().oneTime == true;
        if(lightOn)
        {
            lights.SetActive(true);
            light2.SetActive(true);
        }
    }
}
