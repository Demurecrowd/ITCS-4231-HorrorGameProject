using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScareSound : MonoBehaviour
{
    public AudioSource scareSFX;
    // Start is called before the first frame update
    void Start()
    {
        scareSFX.Play();
    }
}
