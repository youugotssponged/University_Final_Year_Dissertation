/**
* Student ID: 23571144
* Name: Jordan McCann
* File: SpawnTestUnoptimised.cs
* Purpose: To brute force instantiate objects {bouncy balls} to create an unoptimised initial solution. 
*/

using UnityEngine;

public class SpawnTestUnoptimised : MonoBehaviour
{
    public GameObject ball; // Bouncy ball Prefab Reference
    public GameObject theSpawner; // Spawner Placholder Object Reference
    public int ballSize = 2; // Balls to Spawn - Defaulted to 2
    public bool shouldRestart = false; // Bool to decide if the simulation should reset

    private float xbound = 5.0f, ybound = 2.0f, zbound = -13.0f; // Spacing / Padding
    private GameObject spawnerHiarchyLocation; // For parenting the balls to the spawner placeholder for eazy deletion and reset - lazy deletion
    
    private void Start() {
        StartSimulation(); // Starts the initial simulation upon load
    }

    public void Update(){
        // Checks to see if simulation should be reset
        if(shouldRestart){
            RestartSimulation();
        }
    }
    public void StartSimulation(){
        // Creates the spawner instance
        spawnerHiarchyLocation = Instantiate(theSpawner, gameObject.transform);
        // For Every Ball Specified to be created
        for(int i = 0; i < ballSize; i++){
            // Setup fresh spawn position with the padding of the x y z bounds
            Vector3 newBallPos = 
                new Vector3
                (
                    this.transform.position.x + xbound, 
                    this.transform.position.y + ybound, 
                    this.transform.position.z + zbound
                );
            // Instantiate Ball at desired positioned, nested under the spawner that was created in the hiarchy
            Instantiate(ball, newBallPos, Quaternion.identity, spawnerHiarchyLocation.transform);
            ybound += 0.7f; // Increase y padding / spacing
        }
        shouldRestart = false; // Default to false
    }

    public void CleanUp(){
        Destroy(spawnerHiarchyLocation); // Deletes the spawner instance, deleting the balls that have been parented to it
    }

    public void RestartSimulation(){
        CleanUp(); // Destroy instances of the spawner and balls
        ybound = 2.0f; // Reset to initial setting
        StartSimulation(); // Start again
    }
    
}
