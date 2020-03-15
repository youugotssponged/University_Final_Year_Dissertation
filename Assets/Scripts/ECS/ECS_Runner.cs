/**
* Student ID: 23571144
* Name: Jordan McCann
* File: ECS_Runner.cs
* Purpose: To Run The ECS Prototype with internal handler functions to allow the user to quickly reset the test 
*/
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;

public class ECS_Runner : MonoBehaviour
{
    // Data Related
    public static int numOfEntities = 10; // Number of Entities to be Instantiated
    [SerializeField] private Mesh mesh = null; // Mesh to be assigned
    [SerializeField] private Material material = null; // Material to be assigned

    // Control Related
    public static bool shouldRestart = false;

    // Entity Related
    public static EntityManager entityManager; // To store the entity manager that is currently within the scene
    private EntityArchetype entityArchetype; // To create the archetype of what the entity should have
    public static NativeArray<Entity> entityArray; // To Store Entities 

    private void Start()
    {
        StartSimulation(); // Start the initial test
    }

    private void Update()
    {
        // Check to see if a reset was issued by the user
        if (shouldRestart){
            RestartSimulation(); // Restart
        }
    }

    // Upon this monobehavior / Script being destroyed, enforce the cleanup process
    private void OnDestroy()
    {
        CleanUp();
    }

    public void StartSimulation()
    {
        shouldRestart = false; // No Longer Restarting

        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager; // Set the Entity Manager

        entityArchetype = entityManager.CreateArchetype( // Set the structure of the entity
            typeof(ECS_MoveComponent), // The move component
            typeof(Translation), // The Translation component
            typeof(LocalToWorld), // Used to position the entities from local to world space
            typeof(RenderMesh) // The Render Mesh to make the entity visible
        );

        // Create and allocate the NativeArray and set it to be persistent so it doesn't empty by the end of this scope
        entityArray = new NativeArray<Entity>(numOfEntities, Allocator.Persistent); // Would be Temporary stored but needs to be persistent in being able to be held
        
        // Intantiate the entities with the archetype
        entityManager.CreateEntity(entityArchetype, entityArray);

        // For Every Entity In the Entity Array
        for (int i = 0; i < entityArray.Length; i++)
        {
            // Access the current entity
            Entity entity = entityArray[i];

            //// Set Components onto the currently selected entity
            // Move Component
            entityManager.SetComponentData(entity, new ECS_MoveComponent
            {
                movementSpeed = UnityEngine.Random.Range(1f, 10f), // Random Speed between 1-10
                time = Time.deltaTime // deltaTime assigned 
            });

            // Translation Component
            entityManager.SetComponentData(entity, new Translation
            {
                Value = new float3(
                    UnityEngine.Random.Range(-5f, 5f), // Random X
                    UnityEngine.Random.Range(-30f, 30f), // Random Y 
                    0 // Z = 0
                )
            });

            // Set Render Mesh
            // SetSharedComponentData is used to set the same shared data values 
            // into the same chunk in memory as all of the intantiated balls will use the same mesh and material 
            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = mesh,
                material = material
            });
        }
    }

    // Used to destroy all currently running entities
    public static void CleanUp() {
        entityManager.DestroyEntity(entityArray); // Destroy All Active Entities within the NativeArray
        entityArray.Dispose(); // Release the Array From Memory
    }

    // Used to restart the simulation
    public void RestartSimulation() {
        CleanUp(); // Enforce CleanUp
        StartSimulation(); // Invoke StartSimulation Again
    }
}
