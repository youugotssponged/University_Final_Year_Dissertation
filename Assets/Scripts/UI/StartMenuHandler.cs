using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenuHandler : MonoBehaviour
{
    // Mocks the current BUILD SCENE INDEX
    // TODO: Possibly move to a seperate class as the prototypes UI will need to exit back to the main menu
    // Internally Managed - Not good but will do for now
    private enum sceneList{
        START_MENU = 0,
        UNOPTIMISED,
        TRADITIONAL,
        ECS_ONLY,
        ECS_WITH_JOBS,
    }
    
    // Seperate Event Handlers for use within the Buttons OnClick event
    // each 
    public void LoadUnoptimisedTest(){
        int currentScene = (int) sceneList.START_MENU;
        SceneManager.LoadScene(currentScene + (int)sceneList.UNOPTIMISED);
    }

    public void LoadTraditionalTest(){
        int currentScene = (int) sceneList.START_MENU;
        SceneManager.LoadScene(currentScene + (int)sceneList.TRADITIONAL);
    }

    public void LoadECSTest(){
        int currentScene = (int) sceneList.START_MENU;
        SceneManager.LoadScene(currentScene + (int)sceneList.ECS_ONLY);
    }

    public void LoadECSJOBSYSTEMTest(){
        int currentScene = (int) sceneList.START_MENU;
        SceneManager.LoadScene(currentScene + (int)sceneList.ECS_WITH_JOBS);
    }

    public void QuitApplication(){
        // 
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
