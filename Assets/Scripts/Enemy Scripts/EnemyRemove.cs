using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRemove : MonoBehaviour
{
    public GameObject statue;

    private void OnTriggerEnter(Collider other)
    {
        if (statue.activeSelf == true)
        { 
            if (other.tag == "Player")
            {
                statue.SetActive(false);
            }
        }
    }
}
