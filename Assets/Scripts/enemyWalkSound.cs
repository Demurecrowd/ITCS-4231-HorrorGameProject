using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWalkSound : MonoBehaviour
{
    public AudioSource walkSFX;
    // Start is called before the first frame update
    void Start()
    {
        walkSFX.Play();
    }
}
