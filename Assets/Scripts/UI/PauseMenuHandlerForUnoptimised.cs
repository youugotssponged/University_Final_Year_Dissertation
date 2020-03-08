/**
* Student ID: 23571144
* Name: Jordan McCann
* File: PauseMenuHandlerForUnoptimised.cs
* Purpose: To handle the pause menu from the Unoptimised prototype context
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PauseMenuHandlerForUnoptimised : MonoBehaviour
{
    public bool isPaused;
    public string prototypeName = "";
    
    public Text prototypeNameUIText;
    public Canvas PauseUI;

    public InputField inpfield;

    void Start()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        PauseUI.enabled = false;
        prototypeNameUIText.text = "You're currently running on the " + prototypeName + " prototype";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause(){
        Time.timeScale = 0.0f;
        isPaused = true;
        // ENABLE
        PauseUI.enabled = true;
    }

    public void Resume(){
        Time.timeScale = 1.0f;
        isPaused = false;
        // DISABLE
        PauseUI.enabled = false;
    }

    public void Restart(){
        // Call and pass in data from text entry
        int numberofballs = Convert.ToInt32(inpfield.text);

        Resume();

        // Pass to class
        SpawnTestUnoptimised.ballSize = numberofballs;
        SpawnTestUnoptimised.shouldRestart = true;
        inpfield.text = "";
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene((int)SceneList.START_MENU);
    }

}
