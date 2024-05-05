using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndScript : MonoBehaviour
{
    public string nextLevel;
    private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Something Inside Trigger");
            if (other.tag == "Player")
            {
                Debug.Log("Player Inside Trigger");
                SceneManager.LoadScene(nextLevel);
                
            }
        }
}
