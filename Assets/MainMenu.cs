using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Two cameras representing the camera view of the room for the menu, and then the fps camera for the player
    public Camera menucam;

    public Camera playercam;


    //Disables the fps player cam, re-enables user cursor for menu
    void Start()
    {
        playercam.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Temporary solution, checks for return key instead of button click
    void Update()
    {
        if (menucam.enabled != false & Input.GetKey(KeyCode.Return))
        {  
            menucam.enabled = false;
            playercam.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        }
    }
    
    //Not yet working, should run on button click
    //Sets camera enable values to switch cameras to player, then redo cursor stuff
    public void PlayGame()
    {
        menucam.enabled = false;
        playercam.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }


}
