/**
* Student ID: 23571144
* Name: Jordan McCann
* File: ObjectPooler.cs
* Purpose: To manage the spawning and hiding of a list of pooled objects
*/

/*
    This code was created by following a tutorial from
    Author: Brackeys
    Found: https://www.youtube.com/watch?v=tdSmKaJvCoA&list=LLxY4Ccd2weOmHbRlQSdWQeQ&index=5&t=0s
*/

using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    // Serialised Data class for describing what a pool is
    [System.Serializable]
    public class Pool
    {
        public string tag; // Name of the pool
        public GameObject prefab; // Type of object to be placed into the pool
        public int size; // Size of the pool
    }

    public static ObjectPooler Instance; // Singleton Instance as there should only be one ObjectPooler manager
    public List<Pool> pools; // List of pools
    public Dictionary<string, Queue<GameObject>> poolDictionary; // Dictionary of pools and their gameobjects

    public static int currentBallAmmount = 0; // Current amount of balls being tracked

    public GameObject ballPrefab; // Ball prefab to be assigned
    public static int extern_ballSize = 10; // Amount of balls to be allocated - Defaulted to 10
    private void Awake()
    {
        Instance = this; // Set the singleton reference to this instance only
    }

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>(); // Create the dictionary
        
        // Manually Instantiate a Pool to be inserted into the pools List
        Pool ballPool = new Pool();
        ballPool.tag = "Ball"; // Pool labled as ball
        ballPool.prefab = ballPrefab; // Assign the ball prefab
        ballPool.size = extern_ballSize; // Assign the externally set size
        pools.Add(ballPool); // Add to the list

        // For every pool in the pools list => currently 1 => The ballPool
        foreach(Pool pool in pools)
        {
            // Create a new Queue for the objects in the pool
            Queue<GameObject> objectPool = new Queue<GameObject>();

            // For every object in the pool
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab); // Spawn
                obj.SetActive(false); // Hide
                objectPool.Enqueue(obj); // Insert to the queue
            }

            poolDictionary.Add(pool.tag, objectPool); // Add pool to the dictionary
        }
    }

    // Function for spawning an object from a pool with a given position and rotation
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        // If the pool Dictionary has a pool with the string tag
        if (poolDictionary.ContainsKey(tag))
        {
            GameObject objToSpawn = poolDictionary[tag].Dequeue(); // Assign and dequeue object from the pool

            objToSpawn.SetActive(true); // Show object
            objToSpawn.transform.position = position; // assign position
            objToSpawn.transform.rotation = rotation; // assign rotation

            poolDictionary[tag].Enqueue(objToSpawn); // Place back into the pool
            currentBallAmmount++;
            return objToSpawn; // Return object to be spawned
        }
        else
        {
            Debug.LogWarning("Pool with tag " + tag + " does not exist"); // Debug Message
            return null; // Return No Object
        }
    }
}
