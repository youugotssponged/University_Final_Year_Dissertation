/**
* Student ID: 23571144
* Name: Jordan McCann
* File: ECSJOBS_MoveComponent.cs
* Purpose: To store Movement Related Data 
*/

using Unity.Entities; // Entities Namespace

// Data Component
public struct ECSJOBS_MoveComponent : IComponentData
{
    public float movementSpeed; // Movement Speed
    public float time; // Time
}
