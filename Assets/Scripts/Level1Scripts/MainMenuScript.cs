using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //Two cameras representing the camera view of the room for the menu, and then the fps camera for the player
    public GameObject menucam;
    public GameObject player;
    public Animator camAnim;
    public bool switchCam = false;

    public GameObject Canvas;

    //Disables the fps player cam, re-enables user cursor for menu
    void Start()
    {
        player.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Temporary solution, checks for return key instead of button click
    void Update()
    {
        if (menucam.activeSelf & Input.GetKey(KeyCode.Return))
        {  
            //play main cam animation then move to playercam
            
            //menucam.enabled = false;
            //playercam.enabled = true;
            // Cursor.lockState = CursorLockMode.Locked;
            // Cursor.visible = false;
            // GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
            mainCamAnim();
        }
        if (switchCam == true)
        {
            switchCameras();
        }

    }
    
    //Sets camera enable values to switch cameras to player, then redo cursor stuff
    public void PlayGame()
    {
        //menucam.enabled = false;
        //playercam.enabled = true;
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
        // GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        mainCamAnim();
    }

    //Adds functionality to quit button
    public void Quit()
    {
        Debug.Log("Quit triggered");
        Application.Quit();
    }

    public void mainCamAnim()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        camAnim.ResetTrigger("wakeup");
        camAnim.SetTrigger("wakeup");
    }
    public void switchCameras()
    {
        player.SetActive(true);
        menucam.GetComponent<Camera>().enabled = false;
        menucam.GetComponent<AudioListener>().enabled = false;
    }


}
