using UnityEngine;
using UnityEngine.UI;

// Reference Code Snippet
public class FPSCounter : MonoBehaviour
{
    public Text fpsText;
    private float dTime = 0.0f;
    private float fps = 0.0f;
    private float msec = 0.0f;

    void Start()
    {
        fpsText.text = "";    
    }
    void Update()
    {
        dTime += (Time.unscaledDeltaTime - dTime) * 0.1f;
        fps = 1.0f / dTime;
        msec = dTime * 1000.0f;
        fpsText.text = "Number of balls: " + SpawnTestUnoptimised.ballSize + " @ " + string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
    }
}
