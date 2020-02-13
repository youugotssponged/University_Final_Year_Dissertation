using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [TEST CLASS]
// WILL BE REMOVED SOON AS WAS 
// ONLY INTENDED FOR INITIAL BRUTE-FORCED SPAWNING

public class SpawnTest : MonoBehaviour
{
    public GameObject ball; // Bouncy ball Prefab Reference
    public int ballSize = 2; // Number of balls to spawn
    public float xbound = 5.0f; // Default spread
    public float zbound = 5.0f; // Default spread

    // Brute Forced, takes a while @ 10,000 balls => 27FPS~
    private void Start() {
        int i;
        for(i = 0; i < ballSize; i++){
            Vector3 newBallPos = 
                new Vector3
                (
                    this.transform.position.x + xbound, 
                    this.transform.position.y, 
                    this.transform.position.z + zbound
                ); 

            Instantiate(ball, newBallPos, Quaternion.identity);

            // Introduces some kind of spreading as 
            // 10,000 objects spawning and colliding 
            // with each other at the same time in the same 
            // position is bad RIP
            
            xbound += 1.3f; // Increase Spread
            zbound += -0.7f; // Increase Spread

            //Debug.Log("BALL CREATED: " + (i + 1));
        }

        Debug.Log("ALL BALLS INSTANTIATED: " + (i));

    }

    
}
