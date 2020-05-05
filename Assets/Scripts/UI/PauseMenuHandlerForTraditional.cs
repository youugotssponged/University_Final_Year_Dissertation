using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuHandlerForTraditional : MonoBehaviour
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

    public void Restart(){
        // Call and pass in data from text entry
        int numberofballs = Convert.ToInt32(inpfield.text);

        Resume();

        // Pass to class
        ObjectPooler.extern_ballSize = numberofballs;
        inpfield.text = "";
        SceneManager.LoadScene((int) SceneList.TRADITIONAL);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        // DISABLE
        PauseUI.enabled = false;
    }

    // Handles return to main menu button being clicked
    public void ReturnToMainMenu()
    {
        ObjectPooler.Instance.pools.Clear(); // Cleanup operation
        SceneManager.LoadScene((int)SceneList.START_MENU); // Go back to Start Menu
    }
}
