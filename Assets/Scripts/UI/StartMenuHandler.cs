/**
* Student ID: 23571144
* Name: Jordan McCann
* File: StartMenuHandler.cs
* Purpose: To handle the switching of scenes from the start / main menu scene 
*/


using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenuHandler : MonoBehaviour
{   
    // Seperate Event Handlers for use within the Buttons OnClick event
    // each 

    private void Start(){
        Time.timeScale = 1f;
    }

    public void LoadUnoptimisedTest(){
        int currentScene = (int) SceneList.START_MENU;
        SceneManager.LoadScene(currentScene + (int)SceneList.UNOPTIMISED);
    }

    public void LoadTraditionalTest(){
        int currentScene = (int) SceneList.START_MENU;
        SceneManager.LoadScene(currentScene + (int)SceneList.TRADITIONAL);
    }

    public void LoadECSTest(){
        int currentScene = (int) SceneList.START_MENU;
        SceneManager.LoadScene(currentScene + (int)SceneList.ECS_ONLY);
    }

    public void LoadECSJOBSYSTEMTest(){
        int currentScene = (int) SceneList.START_MENU;
        SceneManager.LoadScene(currentScene + (int)SceneList.ECS_WITH_JOBS);
    }

    public void QuitApplication(){
        // 
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
