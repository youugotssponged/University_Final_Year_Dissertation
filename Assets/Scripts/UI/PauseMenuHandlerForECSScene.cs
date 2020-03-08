/**
* Student ID: 23571144
* Name: Jordan McCann
* File: PauseMenuHandlerForECSScene.cs
* Purpose: To handle the pause menu from the ECS ONLY prototype context
*/

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuHandlerForECSScene : MonoBehaviour
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

    public void Pause()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
        // ENABLE
        PauseUI.enabled = true;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        // DISABLE
        PauseUI.enabled = false;
    }

    public void Restart()
    {
        // Call and pass in data from text entry
        int numberofballs = Convert.ToInt32(inpfield.text);

        Resume();

        // Pass to class
        ECS_Runner.numOfEntities = numberofballs;
        ECS_Runner.shouldRestart = true;
        inpfield.text = "";
        ECS_Runner.CleanUp();
        SceneManager.LoadScene((int)SceneList.ECS_ONLY);
    }

    public void ReturnToMainMenu()
    {
        ECS_Runner.CleanUp();
        SceneManager.LoadScene((int)SceneList.START_MENU);
    }
}
