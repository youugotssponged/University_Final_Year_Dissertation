using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Reference Code Snippet
public class FPSCounter : MonoBehaviour
{
    public Text fpsText;
    private float dTime = 0.0f;
    private float fps = 0.0f;
    private float msec = 0.0f;
    private int ballSize;

    void Start()
    {
        fpsText.text = "";

        // Check to see what prototype is currently loaded
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case (int) SceneList.ECS_ONLY:
                ballSize = ECS_Runner.numOfEntities;
                break;
            case (int)SceneList.ECS_WITH_JOBS:
                // TODO: ADD ONCE COMPLETED
                break;
            case (int)SceneList.TRADITIONAL:
                // TODO: ADD ONCE COMPLETED
                break;
            case (int)SceneList.UNOPTIMISED:
                ballSize = SpawnTestUnoptimised.ballSize;
                break;
            default:
                ballSize = 0;
                break;
        }

    }
    void Update()
    {
        dTime += (Time.unscaledDeltaTime - dTime) * 0.1f;
        fps = 1.0f / dTime;
        msec = dTime * 1000.0f;
        fpsText.text = "Number of balls: " + ballSize + " @ " + string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
    }
}
