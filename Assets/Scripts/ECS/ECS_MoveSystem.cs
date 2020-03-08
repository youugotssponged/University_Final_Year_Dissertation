/**
* Student ID: 23571144
* Name: Jordan McCann
* File: ECS_MoveSystem.cs
* Purpose: To handle Entity Movement 
*/


using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class ECS_MoveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        // For Every Entity With a Translation and a MoveComponent
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
