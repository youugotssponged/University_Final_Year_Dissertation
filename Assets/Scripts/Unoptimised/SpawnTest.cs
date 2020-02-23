using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [TEST CLASS]
// WILL BE REMOVED SOON AS WAS 
// ONLY INTENDED FOR INITIAL BRUTE-FORCED SPAWNING

public class SpawnTest : MonoBehaviour
{
    public GameObject ball; // Bouncy ball Prefab Reference
    public GameObject theSpawner; // The Spawner that will be spawning balls
    public int ballSize = 2; // Number of balls to spawn
    public float xbound = 5.0f; // Default spread
    public float zbound = 5.0f; // Default spread
    public float ybound = 1.0f;

    public bool destroy = false;
    public bool shouldRestart = false;

    // Brute Forced, takes a while @ 10,000 balls => 27FPS~
    private void Start() {
        StartSimulation();
    }

    public void Update(){
        if(destroy && !shouldRestart){
            CleanUp();
            destroy = false;
        }
        if(shouldRestart){
            StartSimulation();
        }
    }

    public void CleanUp(){
        Destroy(gameObject);
    }

    public void StartSimulation(){
        if(shouldRestart){
            int i;
            for(i = 0; i < ballSize; i++){
                Vector3 newBallPos = 
                    new Vector3
                    (
                        this.transform.position.x + xbound, 
                        this.transform.position.y + ybound, 
                        this.transform.position.z + zbound
                    ); 

                //Instantiate(ball, newBallPos, Quaternion.identity);
                Instantiate(ball, newBallPos, Quaternion.identity, theSpawner.transform.parent);

                // Introduces some kind of spreading as 
                // 10,000 objects spawning and colliding 
                // with each other at the same time in the same 
                // position is bad RIP
                
                //xbound += 1.3f; // Increase Spread
                //zbound += -0.7f; // Increase Spread
                ybound += 0.5f;
                //Debug.Log("BALL CREATED: " + (i + 1));
            }

            Debug.Log("ALL BALLS INSTANTIATED: " + (i));
        }
    }

    public void RestartSimulation(){
        Instantiate(theSpawner);
        StartSimulation();
    }
    
}
