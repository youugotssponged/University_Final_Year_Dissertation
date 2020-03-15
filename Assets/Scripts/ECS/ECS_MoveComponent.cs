/**
* Student ID: 23571144
* Name: Jordan McCann
* File: ECS_MoveComponent.cs
* Purpose: To store Movement Related Data 
*/

using Unity.Entities; // Entities Namespace - D.O.T.S

// Data Component in the Form of a Struct
public struct ECS_MoveComponent : IComponentData
{
    public float movementSpeed; // Movement Speed
    public float time; // Time, which will be passed in as Time.deltaTime as ECS doesn't know what time is.
}
