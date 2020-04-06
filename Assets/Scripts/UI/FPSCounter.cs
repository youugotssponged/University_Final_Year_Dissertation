/**
* Student ID: 23571144
* Name: Jordan McCann
* File: FPSCounter.cs
* Purpose: To draw and update a small FPS counter with some context
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FPSCounter : MonoBehaviour
{
    public Text fpsText; // UI Text to be updated
    private float dTime = 0.0f; // time difference
    private float fps = 0.0f; // FPS
    private float msec = 0.0f; // Milisec response time
    private int ballSize; // Ball size of the current test 

    void Start()
    {
        fpsText.text = ""; // Empty UI text

        // Check to see what prototype is currently loaded
        // And Set ballsize based on what's currently being spawned
        CheckBallAmountOnScreen();
    }
    void Update()
    {
        CheckBallAmountOnScreen();
        CalcFPS();
    }

    private void CalcFPS()
    {
        /*
            The FPS Calculation code was taken and used from - 
            Author: Dave Hapson
            From: https://wiki.unity3d.com/index.php/FramesPerSecond 
        */

        dTime += (Time.unscaledDeltaTime - dTime) * 0.1f; // Get the difference in timing between frames
        fps = 1.0f / dTime;
        msec = dTime * 1000.0f;
        fpsText.text = "Number of balls: " + ballSize + " @ " + string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
    }

    private void CheckBallAmountOnScreen()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case (int)SceneList.ECS_ONLY:
                ballSize = ECS_Runner.numOfEntities;
                break;
            case (int)SceneList.ECS_WITH_JOBS:
                ballSize = ECSJOBS_Runner.numOfEntities;
                break;
            case (int)SceneList.TRADITIONAL:
                ballSize = ObjectPooler.Instance.pools[0].size;
                break;
            case (int)SceneList.UNOPTIMISED:
                ballSize = SpawnTestUnoptimised.ballSize;
                break;
            default:
                ballSize = 0;
                break;
        }
    }
}
