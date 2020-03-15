/**
* Student ID: 23571144
* Name: Jordan McCann
* File: ECSJOBS_MoveSystem.cs
* Purpose: To Handle Entities for the ECS C# JOBS Prototype 
*/

// D.O.T.S Namespaces
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst; // Burst Compiler Namespace
using Unity.Jobs; // C# Jobs Namespace for Multithreading 
using Unity.Collections; // (SIMD) Containers Namespace- NativeArray

public class ECSJOBS_MoveSystem : JobComponentSystem
{
    [BurstCompile] // Burst Compiler Attibute
    private struct MoveJob : IJobForEach<Translation, ECSJOBS_MoveComponent> // Job to run on every Entity with a translation and Move Component
    {
        // Execute that gets invoked by the Job System
        public void Execute(ref Translation translation, ref ECSJOBS_MoveComponent moveComponent)
        {
            // Update X and Y
            translation.Value.y += moveComponent.movementSpeed * moveComponent.time;
            translation.Value.x += moveComponent.movementSpeed * moveComponent.time;

            // If Y is within bounds, flip speed - reversing travel
            if (translation.Value.y > 5f)
            {
                moveComponent.movementSpeed = -math.abs(moveComponent.movementSpeed);
            }

            // If Y is within bounds, flip speed - reversing travel
            if (translation.Value.y < -5f)
            {
                moveComponent.movementSpeed = +math.abs(moveComponent.movementSpeed);
            }
        }
    }

    // OnUpdate which returns a JobHandle - thread
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var jobHandle = new MoveJob { }; // Create the Job
        jobHandle.Schedule(this, inputDeps).Complete(); // Schedule and Complete Straight Away

        return inputDeps; // Return a job handle
    }
}
