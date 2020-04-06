using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenuHandlerForECSJOBS : MonoBehaviour
{
    public bool isPaused; // Used to keep track of the paused state
    public string prototypeName = ""; // Prototype name string of the currently running prototype

    public Text prototypeNameUIText; // UI Text component reference
    public Canvas PauseUI; // Reference to the Pause Menu UI Canvas

    public InputField inpfield; // Input Field Component 

    void Start()
    {
        Time.timeScale = 1.0f; // Ensure timescale is set to normal
        isPaused = false; // Currently not paused
        PauseUI.enabled = false; // Don't show UI on start
        prototypeNameUIText.text = "You're currently running on the " + prototypeName + " prototype"; // Assign prototype name to Text component
    }

    // Update is called once per frame
    void Update()
    {
        // If Escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If already paused
            if (isPaused)
            {
                Resume(); // Resume the application
            }
            else // Otherwise
            {
                Pause(); // Pause the application
            }
        }
    }

    // Handles Pause Event
    public void Pause()
    {
        Time.timeScale = 0.0f; // Freezes the timescale
        isPaused = true; // Sets the pause state
        // ENABLE
        PauseUI.enabled = true; // Shows the Pause Menu UI
    }

    // Handles Resume Event
    public void Resume()
    {
        Time.timeScale = 1.0f; // Unfreezes the timescale
        isPaused = false; // Sets the pause state
        // DISABLE
        PauseUI.enabled = false; // Hide the pause menu ui
    }

    // Used to handle the restart button being clicked
    public void Restart()
    {
        // Call and pass in data from text entry
        int numberofballs = Convert.ToInt32(inpfield.text);

        Resume(); // Resume Application

        // Pass to data to class being run
        ECSJOBS_Runner.numOfEntities = numberofballs; // 
        ECSJOBS_Runner.shouldRestart = true; // Toggle restart operation
        inpfield.text = ""; // Clear input field
        ECSJOBS_Runner.CleanUp(); // Run Cleaup operation
        SceneManager.LoadScene((int)SceneList.ECS_WITH_JOBS); // Reload Scene
    }

    // Used to handle the return to main menu button being clicked
    public void ReturnToMainMenu()
    {
        ECSJOBS_Runner.CleanUp(); // Run Cleanup operation
        SceneManager.LoadScene((int)SceneList.START_MENU); // Go back to start menu
    }
}
