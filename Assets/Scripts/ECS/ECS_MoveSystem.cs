/**
* Student ID: 23571144
* Name: Jordan McCann
* File: ECS_MoveSystem.cs
* Purpose: To handle Entity Movement 
*/


using Unity.Entities; // Entities Namespace - D.O.T.S
using Unity.Transforms; // Transforms Namespace - D.O.T.S
using Unity.Mathematics; // The new Math (SIMD) library - D.O.T.S

// The System - To handle and update the moving objects
public class ECS_MoveSystem : ComponentSystem
{
    // Component System's have their own lifecycles similar to MONOBEHAVIOUR's Update()
    protected override void OnUpdate()
    {
        // For Every Entity With a Translation and a MoveComponent,
        // Which takes a comma seperated list of types as an entity query 
        // and a callback() will be invoked on those entities
        Entities.ForEach((ref Translation translation, ref ECS_MoveComponent moveComponent) => {

            // Increase the Translations X & Y by speed and time
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
        });
    }
}
