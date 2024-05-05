using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    //Variables for pause state and display state
    public static bool isPaused = false;

    public GameObject pauseUI;
    

    void Update()
    {
        //Checks input for pause button
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    //Main Functionality
    void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

}
