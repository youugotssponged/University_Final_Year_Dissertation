/**
* Student ID: 23571144
* Name: Jordan McCann
* File: BallSpawner.cs
* Purpose: To spawn ball objects using the created ObjectPooler.cs class
*/

/*
    This code was created by following a tutorial from
    Author: Brackeys
    Found: https://www.youtube.com/watch?v=tdSmKaJvCoA&list=LLxY4Ccd2weOmHbRlQSdWQeQ&index=5&t=0s
*/

using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    ObjectPooler objectPooler; // Object Pooler reference

    private void Start()
    {
        objectPooler = ObjectPooler.Instance; // Assign ObjectPooler Reference
    }

    // Physics based update per frame
    private void Update()
    {   
        // If the current amount is not the specificied amount to be spawned
        if(ObjectPooler.currentBallAmmount != ObjectPooler.extern_ballSize) {
            // Spawn a ball from the allocated pool
            objectPooler.SpawnFromPool("Ball", transform.position, Quaternion.identity); // Spawn a ball object from the allocated pool.
        }
    }
}
