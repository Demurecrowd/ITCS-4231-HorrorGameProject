using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRunSound : MonoBehaviour
{
    public AudioSource runSFX;
    // Start is called before the first frame update
    void Start()
    {
        runSFX.Play();
    }
}
