/**
* Student ID: 23571144
* Name: Jordan McCann
* File: ECS_MoveComponent.cs
* Purpose: To store Movement Related Data 
*/

using Unity.Entities;

public struct ECS_MoveComponent : IComponentData
{
    public float movementSpeed;
    public float time; 
}
