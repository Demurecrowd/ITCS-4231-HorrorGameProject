using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light m_light;
    public bool drainOverTime, hasLight = true;
    public float maxBrightness;
    public float minBrightness;
    public float drainRate;
    public float rechargeRate;
    // Start is called before the first frame update
    void Start()
    {
        m_light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Flashlight Drain
        m_light.intensity = Mathf.Clamp(m_light.intensity,minBrightness,maxBrightness);
        if(drainOverTime == true && m_light.enabled == true)
        {
            if(m_light.intensity > minBrightness)
            {
                m_light.intensity -= Time.deltaTime * (drainRate/1000);
            }
            if(m_light.intensity == minBrightness)
            {
                m_light.enabled = !m_light.enabled;
            }
        }
        #endregion
        
        #region Flashlight Recharge
        if(drainOverTime == true && m_light.enabled == false)
        {
            if(Input.GetKey("r")){
             if(m_light.intensity < maxBrightness)
                {
                //Set up recharge animation and timer instead of a recharge rate
                m_light.intensity += Time.deltaTime * (rechargeRate/1000);
                }
            }
        }
        #endregion

        #region Flashlight activiation
        if (hasLight == true)
        {
            if (Input.GetKeyDown("f"))
            {
                if (m_light.intensity > minBrightness){
                    m_light.enabled = !m_light.enabled;
                }
            }
        }
       #endregion

    //    if (Input.GetKeyDown("r"))
    //    {
    //     ReplaceBattery(.3f);
    //    }
    }
    //Need to add timer to make it a recharging battery
    // public void ReplaceBattery(float amount)
    // {
    //     m_light.intensity += amount;
    // }
}
