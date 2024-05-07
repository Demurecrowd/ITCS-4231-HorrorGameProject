using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoaderScript : MonoBehaviour
{
    public string nextLevel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
