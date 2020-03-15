/**
* Student ID: 23571144
* Name: Jordan McCann
* File: ECSJOBS_Runner.cs
* Purpose: To Run The ECS WITH JOBS Prototype with internal handler functions to allow the user to quickly reset the test 

Note: This Script is Unchanged from the Original ECS Runner as this purely is the authoring component 
      just to create the entities via the Entity Manager
*/
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;

public class ECSJOBS_Runner : MonoBehaviour
{
    // Data Related
    public static int numOfEntities = 10;
    [SerializeField] private Mesh mesh = null;
    [SerializeField] private Material material = null;

    // Control Related
    public static bool shouldRestart = false;

    // Entity Related
    public static EntityManager entityManager; // To store the entity manager that is currently within the scene
    private EntityArchetype entityArchetype; // To create the archetype of what the entity should have
    public static NativeArray<Entity> entityArray; // To Store Entities 

    private void Start()
    {
        StartSimulation();
    }

    private void Update()
    {
        // Check to see if a reset was issued by the user
        if (shouldRestart)
        {
            RestartSimulation(); // Restart
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }

    private void StartSimulation()
    {
        shouldRestart = false; // No Longer Restarting

        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        entityArchetype = entityManager.CreateArchetype(
            typeof(ECSJOBS_MoveComponent),
            typeof(Translation),
            typeof(LocalToWorld),
            typeof(RenderMesh)
        );

        entityArray = new NativeArray<Entity>(numOfEntities, Allocator.Persistent);

        entityManager.CreateEntity(entityArchetype, entityArray);

        for(int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];

            //// Set Components onto the currently selected entity
            // Move Component
            entityManager.SetComponentData(entity, new ECSJOBS_MoveComponent
            {
                movementSpeed = UnityEngine.Random.Range(1f, 10f),
                time = Time.deltaTime
            });

            // Translation Component
            entityManager.SetComponentData(entity, new Translation
            {
                Value = new float3(
                    UnityEngine.Random.Range(-5f, 5f),
                    UnityEngine.Random.Range(-30f, 30f), 0
                )
            });

            // Set Render Mesh
            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = mesh,
                material = material
            });
            
        }
    }

    public static void CleanUp()
    {
        entityManager.DestroyEntity(entityArray); // Destroy All Active Entities within the NativeArray
        entityArray.Dispose(); // Release the Array From Memory
    }

    public void RestartSimulation()
    {
        CleanUp();
        StartSimulation();
    }

}
